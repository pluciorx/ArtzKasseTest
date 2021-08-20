using Drugs.BL;
using DrugsHost.Controllers;
using log4net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Threading.Tasks;
using Drugs.BL.Interfaces;

namespace DrugsHost
{
    public class Startup
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Startup));
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;


            /* klasa Monitor obecnie nie jest wykorzystywana w prognozach, wymaga sporych dopracowañ 
            //var monitorController = new MonitorController();
            //Task.Run(() => monitorController.StartMonitor());
            //log.Info("GTFS Monitoring feed started. ");
            */

            CheckConfiguration();

#if DEBUG==false
           // Task.Run(() => ztmcontroller.StartTimer());
            log.Info("ZTM vehicles position service started.");
#endif
        }

        private void CheckConfiguration()
        {
            if (string.IsNullOrEmpty(Configuration["DIP_DbConnString"]))
            {
                throw new System.Exception("Missing config Key:DIP_DbConnString");
            }
        }

       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();            
            services.AddHealthChecks();
            services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_CONNECTIONSTRING"]);
            var filePath = Path.Combine(System.AppContext.BaseDirectory, "DipCore.Host.xml");
            services.AddSwaggerGen(c => c.IncludeXmlComments(filePath));

            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IDrugsRepository, GtfsRepository>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
                endpoints.MapHealthChecks("/");
                endpoints.MapControllers();
            });

          
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Drugs API");
                       
            });
        }
    }
}

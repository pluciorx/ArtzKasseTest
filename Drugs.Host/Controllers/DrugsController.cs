using Drugs.BL.Interfaces;
using Drugs.Entities;
using log4net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrugsHost.Controllers
{
 
    [ApiController]
    [Route("[controller]")]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DrugsController : ControllerBase
    {

        private static readonly ILog log = LogManager.GetLogger(typeof(DrugsController));
        private readonly IDrugService drugService;

        public DrugsController(IDrugService _drugService)
        {
            drugService = _drugService;
        }

        [HttpGet("/DrugList")]
        //[Authorize]
        public async Task<IEnumerable<Drug>> DrugList([FromQuery] string code,[FromQuery] string label)
        {
            var dList = await drugService.GetDrugListAsync(code, label);
            return dList;
        }

    }
}

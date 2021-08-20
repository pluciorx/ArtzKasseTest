using Drugs.BL;
using Drugs.BL.Interfaces;
using log4net;
using Microsoft.AspNetCore.Mvc;

namespace DrugsHost.Controllers
{
 
    [ApiController]
    [Route("[controller]")]
    public class DrugsController : ControllerBase
    {

        private static readonly ILog log = LogManager.GetLogger(typeof(DrugsController));


        public DrugsController()
        {

        }

    }
}

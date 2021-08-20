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

        /// <summary>
        /// Get's the drug List
        /// </summary>
        /// <param name="code"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        [HttpGet("/DrugList")]
        //[Authorize]
        public async Task<IEnumerable<Drug>> DrugList([FromQuery] string code, [FromQuery] string label)
        {
            var dList = await drugService.GetDrugListAsync(code, label);
            return dList;
        }

        /// <summary>
        /// Gets single drug by it's ID
        /// </summary>
        /// <param name="drugId"></param>
        /// <returns></returns>
        [HttpGet("/Drug")]
        //[Authorize]
        public async Task<Drug> Drug([FromQuery] string drugId)
        {
            if (int.TryParse(drugId, out int intId))
            {
                return await drugService.GetDrugAsync(intId);
            }
            return null;

        }

        [HttpPut("/Drug/{drugid}")]
        //[Authorize]
        public async Task<bool> Drug([FromRoute] int drugid,[FromBody] Drug drug)
        {

            return await drugService.UpdateDrug(drug);

        }

        [HttpPost("/Drug")]
        //[Authorize]
        public async Task<int> UpdateDrug([FromBody] Drug drug)
        { 
           return await drugService.InsertDrugAsync(drug);
        }

        [HttpDelete("/Drug/{drugid}")]
        //[Authorize]
        public async Task<bool> DeleteDrug(int drugid)
        {
            return await drugService.DeleteDrugAsync(drugid);
        }
    }
}

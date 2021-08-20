using Drugs.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Drugs.BL.Interfaces
{
    public interface IDrugService
    {
        public Task<IEnumerable<Drug>> GetDrugListAsync(string code = null, string label = null);
    }
}

using Drugs.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Drugs.BL.Interfaces
{
    public interface IDrugService
    {
        public Task<IEnumerable<Drug>> GetDrugListAsync(string code = "", string label = "");

        public Task<bool> DeleteDrugAsync(int drugId);

        public Task<int> InsertDrugAsync(Drug drug);
        public Task<bool> UpdateDrug(Drug drug);
        public Task<Drug> GetDrugAsync(int drugId);
    }
}

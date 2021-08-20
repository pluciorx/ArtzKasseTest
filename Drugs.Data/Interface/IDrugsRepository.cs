using Drugs.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Drugs.Data.Interfaces
{
    public interface IDrugsRepository
    {
        public Task<IEnumerable<Drug>> GetDrugListAsync(string code = null, string label = null);

        public Task<bool> DeleteDrugAsync(int drugId);

        public Task<int> InsertDrug(Drug drug);
        public Task<bool> UpdateDrug(Drug drug);
        public Task<Drug> GetDrugAsync(int drugId);

    } 
}
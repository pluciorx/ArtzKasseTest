using Drugs.BL.Interfaces;
using Drugs.Data.Interfaces;
using Drugs.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Drugs.BL
{
    public class DrugService : IDrugService
    {
        private readonly IDrugsRepository drugsRepository;
        public DrugService(IDrugsRepository _repository)
        {
            drugsRepository = _repository;
        }

        public async Task<bool> DeleteDrugAsync(int drugId)
        {
            return await drugsRepository.DeleteDrugAsync(drugId);
        }

        public async Task<Drug> GetDrugAsync(int drugId)
        {
           return await drugsRepository.GetDrugAsync(drugId);
        }

        public async Task<IEnumerable<Drug>> GetDrugListAsync(string code = null, string label = null)
        {
            var response = await drugsRepository.GetDrugListAsync(code, label);
            return response;

        }

        public Task<int> InsertDrugAsync(Drug drug)
        {
            //Add validation of entitiy 
            return drugsRepository.InsertDrug(drug);
        }

        public Task<bool> UpdateDrug(Drug drug)
        {
            return drugsRepository.UpdateDrug(drug);
        }
    }
}

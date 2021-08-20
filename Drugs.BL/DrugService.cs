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
        public async Task<IEnumerable<Drug>> GetDrugListAsync(string code = null, string label = null)
        {
            var response = await drugsRepository.GetDrugListAsync(code, label);
            return response;

        }
    }
}

using Drugs.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Drugs.Data.Interfaces
{
    public interface IDrugsRepository
    {
        public Task<IEnumerable<Drug>> GetDrugListAsync(string code, string label);
    } 
}
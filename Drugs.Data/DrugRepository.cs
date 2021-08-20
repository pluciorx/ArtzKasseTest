using Dapper;
using Drugs.Data.Interfaces;
using Drugs.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Drugs.Data
{
    public class DrugsRepository :BaseRepository,IDrugsRepository
    {
        public DrugsRepository(IConfiguration configuration) : base(configuration)
        {

        }

        async Task<IEnumerable<Drug>> IDrugsRepository.GetDrugListAsync(string code, string label)
        {
            using IDbConnection db = Connection;
           
            var dbResponse =  await db.QueryAsync<Drug>("[spGetDrugList]", new { code, label });
            return dbResponse;
        }
    }
}

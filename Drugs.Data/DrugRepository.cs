using Dapper;
using Dapper.Contrib.Extensions;
using Drugs.Data.Interfaces;
using Drugs.Entities;
using log4net;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Drugs.Data
{
    public class DrugsRepository : BaseRepository, IDrugsRepository
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DrugsRepository));
        public DrugsRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<bool> DeleteDrugAsync(int drugId)
        {
            try
            {
                using IDbConnection db = Connection;
                var dbResponse = await db.ExecuteAsync("Delete From Drugs Where drugId = @drugId", drugId);
                return dbResponse == 1;
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                return false;
            }

        }

        public async Task<Drug> GetDrugAsync(int drugId)
        {
            using IDbConnection db = Connection;
            var param = new { drugId };
            var dbResponse = await db.QuerySingleAsync<Drug>("Select * from Drugs Where drugId = @drugId", param);
            return dbResponse;
        }

        public async Task<int> InsertDrug(Drug drug)
        {
            using IDbConnection db = Connection;
            var dbResponse = await db.InsertAsync(drug);
            return dbResponse;
        }

        public async Task<bool> UpdateDrug(Drug drug)
        {
            using IDbConnection db = Connection;
            var dbResponse = await db.UpdateAsync(drug);
            return dbResponse;
        }

        public async Task<IEnumerable<Drug>> GetDrugListAsync(string code = "", string label = "")
        {
            using IDbConnection db = Connection;
            var param = new { code = code, label = label };
            var dbResponse = await db.QueryAsync<Drug>("[spGetDrugList]", param, commandType: CommandType.StoredProcedure);
            return dbResponse;
        }
    }
}

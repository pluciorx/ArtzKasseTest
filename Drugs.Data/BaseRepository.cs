using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Drugs.Data
{
    public class BaseRepository
    {
        public string ConnectionString;
        public BaseRepository(IConfiguration configuration)
        {
            ConnectionString = configuration["DbConnString"];
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }
    }
}
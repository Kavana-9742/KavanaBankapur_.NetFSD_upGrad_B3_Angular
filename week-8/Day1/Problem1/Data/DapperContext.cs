using System.Data;
using Microsoft.Data.SqlClient;

namespace WebApplication9.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _config;
        private readonly String _connectionString;
        public DapperContext(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}

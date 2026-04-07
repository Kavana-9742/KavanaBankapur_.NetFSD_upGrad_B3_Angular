using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApplication10.Models
{
    public class DapperContext
    {
        private readonly IConfiguration _config;
        private readonly string _connStr;

        public DapperContext(IConfiguration config)
        {
            _config = config;
            _connStr = _config.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connStr);
    }
}

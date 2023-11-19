using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobMarley.Infra.Context
{
    public class AuroraDbContext
    {
        public readonly string _connectionString;

        public AuroraDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);

    }
}
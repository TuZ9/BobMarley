using Npgsql;
using System.Data;

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
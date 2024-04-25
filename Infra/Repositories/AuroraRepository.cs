using BobMarley.Domain.Interfaces.Repositories;
using BobMarley.Infra.Context;
using Dapper;

namespace BobMarley.Infra.Repositories
{
    public class AuroraRepository<TEntity> : IDisposable, IAuroraRepository<TEntity> where TEntity : class
    {
        protected AuroraDbContext _context;

        public AuroraRepository(AuroraDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(string query, object? param = null)
        {
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, param);
            }
        }

        public void Dispose()
        {
        }

        public async Task<TEntity> GetAsync(string query, object? param = null)
        {
            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryAsync<TEntity>(query, param);
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(string query, object? param = null)
        {
            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryAsync<TEntity>(query, param);
                return result;
            }
        }

        public async Task InsertAsync(string query, object? param = null)
        {
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, param);
            }
        }

        public async Task UpdateAsync(string query, object? param = null)
        {
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, param);
            }
        }
    }
}

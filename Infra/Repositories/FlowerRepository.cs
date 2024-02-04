using BobMarley.Domain.Entities;
using BobMarley.Domain.Interfaces.Repositories;
using BobMarley.Infra.Context;
using Dapper;

namespace BobMarley.Infra.Repositories
{
    public class FlowerRepository : IFlowerRepository
    {
        private readonly AuroraDbContext _context;
        public FlowerRepository(AuroraDbContext context)
        {
            _context = context;
        }

        public async Task DeleteFlower(Flower flower)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "";
                    var result = await connection.QueryAsync<Flower>(query, param: new { });
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<IEnumerable<Flower>> GetFlower()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "";
                    var result = await connection.QueryAsync<Flower>(query, param: new { });
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task InsertFlower(IEnumerable<Flower> flower)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "";
                    var result = await connection.QueryAsync<Flower>(query, param: new { });
                }
            }
            catch (Exception ex)
            {

            }
        }

        public Task UpdateFlower(IEnumerable<Flower> flower)
        {
            throw new NotImplementedException();
        }
    }
}

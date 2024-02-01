using BobMarley.Domain.Entities;
using BobMarley.Domain.Interfaces.Repositories;
using BobMarley.Infra.Context;

namespace BobMarley.Infra.Repositories
{
    public class FlowerRepository : AuroraRepository<Flower>, IFlowerRepository
    {
        public FlowerRepository(AuroraDbContext context) : base(context)
        {
        }

        public async Task DeleteFlower(Flower flower)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {

                }
            }
            catch (Exception ex)
            {

            }
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Flower>> GetFlower()
        {
            throw new NotImplementedException();
        }

        public Task InsertFlower(IEnumerable<Flower> flower)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFlower(IEnumerable<Flower> flower)
        {
            throw new NotImplementedException();
        }
    }
}

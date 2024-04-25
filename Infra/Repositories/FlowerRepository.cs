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

        public Task DeleteFlower(Flower flower)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        public Task<IEnumerable<Flower>> GetFlower()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task InsertFlower(IEnumerable<Flower> flower)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task UpdateFlower(IEnumerable<Flower> flower)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

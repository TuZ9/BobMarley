
using BobMarley.Domain.Entities;

namespace BobMarley.Domain.Interfaces.Repositories
{
    public interface IFlowerRepository
    {
        Task<IEnumerable<Flower>> GetFlower();
        Task InsertFlower(IEnumerable<Flower> flower); 
        Task UpdateFlower(IEnumerable<Flower> flower); 
        Task DeleteFlower(Flower flower);
    }
}

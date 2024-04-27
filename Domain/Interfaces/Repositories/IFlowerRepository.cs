
using BobMarley.Domain.Entities;

namespace BobMarley.Domain.Interfaces.Repositories
{
    public interface IFlowerRepository
    {
        Task<IEnumerable<Flower>> Get();
        Task Insert(IEnumerable<Flower> flower); 
        Task Update(IEnumerable<Flower> flower); 
        Task Delete(Flower flower);
    }
}

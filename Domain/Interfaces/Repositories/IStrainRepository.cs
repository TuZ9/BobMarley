
using BobMarley.Domain.Entities;

namespace BobMarley.Domain.Interfaces.Repositories
{
    public interface IStrainRepository
    {
        Task<IEnumerable<Strain>> GetStrain();
        Task Insert(IEnumerable<Strain> flower); 
        Task Update(IEnumerable<Strain> flower); 
        Task Delete(Strain flower);
    }
}

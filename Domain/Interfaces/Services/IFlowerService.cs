
namespace BobMarley.Domain.Interfaces.Services
{
    public interface IFlowerService
    {
        Task BuildBase();

        Task RunGpt();
    }
}

using BobMarley.Domain.Interfaces.ApiClientService;
using BobMarley.Domain.Interfaces.Repositories;
using BobMarley.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using BobMarley.Domain.Dto;

namespace BobMarley.Application.Services
{
    public class FlowerService : IFlowerService
    {
        private readonly ILogger<FlowerService> _logger;
        private readonly IFlowerRepository _flowerRepository;
        private readonly IFlowerApiClient _flowerApiClient;
        public FlowerService(ILogger<FlowerService> logger, IFlowerRepository flowerRepository, IFlowerApiClient flowerApiClient)
        {
            _logger = logger;
            _flowerRepository = flowerRepository;
            _flowerApiClient = flowerApiClient;
        }
        public async Task BuildBase()
        {
            try
            {
                var lisfFlower = new List<FlowerDto>();
                var i = 0;
                while (i<=100)
                {
                    i++;
                    var flowers = await _flowerApiClient.GetAsync($"/v1/flowers?page={i}&count=50");
                    if (flowers.data.Count != 0 || flowers != null)
                    {
                        lisfFlower.AddRange(flowers.data);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }
    }
}

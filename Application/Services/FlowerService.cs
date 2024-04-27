using BobMarley.Domain.Interfaces.ApiClientService;
using BobMarley.Domain.Interfaces.Repositories;
using BobMarley.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using BobMarley.Domain.Entities;
using static Dapper.SqlMapper;
using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using BobMarley.Domain.Dto.Root;

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
                //var http = new HttpClient();

                //var httpResponseMessage = await http.GetAsync("https://api.otreeba.com/v1/flowers?count=1000");

                ////var resultw = JsonSerializer.Deserialize<Root>(contentStream);

                //if (httpResponseMessage.IsSuccessStatusCode)
                //{
                //    var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                //    var result = JsonSerializer.Deserialize<RootFlower>(contentStream);

                //    var s = result;
                //    //return result;
                //}

                var flowers = await _flowerApiClient.GetAsync($"v1/flowers?count=1000");

                var a = flowers;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}",ex.Message);
                throw;
            }
        }
    }
}

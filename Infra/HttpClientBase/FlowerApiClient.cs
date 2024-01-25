using BobMarley.Application.Services;
using BobMarley.Domain.Entities;
using BobMarley.Domain.Interfaces.ApiClientService;
using Microsoft.Extensions.Logging;

namespace BobMarley.Infra.HttpClientBase
{
    public class FlowerApiClient : ServiceClientBase<Flower, FlowerApiClient>, IFlowerApiClient
    {
        public FlowerApiClient(HttpClient httpClient, ILogger<FlowerApiClient> logger) : base(httpClient, logger)
        {
        }
    }
}
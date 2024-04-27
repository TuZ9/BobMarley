using BobMarley.Application.Services;
using BobMarley.Domain.Dto;
using BobMarley.Domain.Dto.Root;
using BobMarley.Domain.Interfaces.ApiClientService;
using Microsoft.Extensions.Logging;

namespace BobMarley.Infra.HttpClientBase
{
    public class FlowerApiClient : ServiceClientBase<RootFlower, FlowerApiClient>, IFlowerApiClient
    {
        public FlowerApiClient(IHttpClientFactory clientFactory, ILogger<FlowerApiClient> logger, string clientName) : base(clientFactory, logger, clientName)
        {
        }
    }
}
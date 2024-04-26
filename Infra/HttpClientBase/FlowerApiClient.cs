using BobMarley.Application.Services;
using BobMarley.Domain.Dto;
using BobMarley.Domain.Entities;
using BobMarley.Domain.Interfaces.ApiClientService;
using Microsoft.Extensions.Logging;

namespace BobMarley.Infra.HttpClientBase
{
    public class FlowerApiClient : ServiceClientBase<FlowerDto, FlowerApiClient>, IFlowerApiClient
    {
        public FlowerApiClient(HttpClient httpClient, ILogger<FlowerApiClient> logger) : base(httpClient, logger)
        {
        }
    }
}
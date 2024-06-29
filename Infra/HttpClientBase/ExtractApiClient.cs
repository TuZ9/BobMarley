using BobMarley.Application.Services;
using BobMarley.Domain.Dto;
using BobMarley.Domain.Interfaces.ApiClientService;
using Microsoft.Extensions.Logging;

namespace BobMarley.Infra.HttpClientBase
{
    public class ExtractApiClient : ServiceClientBase<ExtractDto, ExtractApiClient>, IExtractApiClient
    {
        public ExtractApiClient(IHttpClientFactory clientFactory, ILogger<ExtractApiClient> logger, string clientName) : base(clientFactory, logger, clientName)
        {
        }
    }
}

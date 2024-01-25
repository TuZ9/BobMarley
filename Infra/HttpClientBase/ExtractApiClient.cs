using BobMarley.Application.Services;
using BobMarley.Domain.Entities;
using BobMarley.Domain.Interfaces.ApiClientService;
using Microsoft.Extensions.Logging;

namespace BobMarley.Infra.HttpClientBase
{
    public class ExtractApiClient : ServiceClientBase<Extract, ExtractApiClient>, IExtractApiClient
    {
        public ExtractApiClient(HttpClient httpClient, ILogger<ExtractApiClient> logger) : base(httpClient, logger)
        {
        }
    }
}

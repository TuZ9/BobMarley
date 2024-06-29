using BobMarley.Application.Services;
using BobMarley.Domain.Dto;
using BobMarley.Domain.Interfaces.ApiClientService;
using Microsoft.Extensions.Logging;

namespace BobMarley.Infra.HttpClientBase
{
    public class StrainApiClient : ServiceClientBase<StrainDto, StrainApiClient>, IStrainApiClient
    {
        public StrainApiClient(IHttpClientFactory clientFactory, ILogger<StrainApiClient> logger, string clientName) : base(clientFactory, logger, clientName)
        {
        }
    }
}

using BobMarley.Application.Services;
using BobMarley.Domain.Dto;
using BobMarley.Domain.Interfaces.ApiClientService;
using Microsoft.Extensions.Logging;

namespace BobMarley.Infra.HttpClientBase
{
    public class StrainApiClient : ServiceClientBase<StrainDto, StrainApiClient>, IStrainApiClient
    {
        public StrainApiClient(HttpClient httpClient, ILogger<StrainApiClient> logger) : base(httpClient, logger)
        {
        }
    }
}


using MyApp.Interfaces;
using MyApp.Models;
using MyApp.Utils;
using Newtonsoft.Json;

namespace MyApp.Services
{
    public class GeoEntityService:IGeoEntityService
    {
        private readonly ILogger<GeoEntityService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IGeoEntityRepository _geoEntityRepository;

        public GeoEntityService(ILogger<GeoEntityService> logger, IHttpClientFactory httpClientFactory,IGeoEntityRepository geoEntityRepository)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _geoEntityRepository = geoEntityRepository;
        }
        /// <summary>
        /// Method to get the state details
        /// </summary>
        public async Task MergeStateDetails()
        {
            var states = await GetResponseMessage(Constants.STATEURI, Constants.APIKEY, Constants.STATEHOST);
            if (states != null)
            {
                await _geoEntityRepository.MergeStateDetails(states);
                await MergeCountyDetails();
            }
        }

        /// <summary>
        /// Method to get the county details
        /// </summary>
        public async Task MergeCountyDetails()
        {
            var counties = await GetResponseMessage(Constants.COUNTYURI, Constants.APIKEY, Constants.COUNTYHOST);
            if (counties != null)
            {
                await _geoEntityRepository.MergeCountyDetails(counties);
            }
        }

        /// <summary>
        /// Get the response message
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="xRapidAPIKey"></param>
        /// <param name="xRapidAPIHost"></param>
        /// <returns></returns>
        private async Task<string> GetResponseMessage(string requestUri, string xRapidAPIKey, string xRapidAPIHost)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(requestUri),
                    Headers = { { "X-RapidAPI-Key", xRapidAPIKey }, { "X-RapidAPI-Host", xRapidAPIHost }, },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}

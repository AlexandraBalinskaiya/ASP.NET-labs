using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace lr9.Models
{
    public class WeatherService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public WeatherService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<WeatherData> GetWeatherAsync(string region)
        {
            var apiKey = _configuration["WeatherApi:ApiKey"];
            var url = $"{_configuration["WeatherApi:BaseUrl"]}weather?q={region}&appid={apiKey}&units=metric";
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<WeatherData>(response);
        }
    }
}

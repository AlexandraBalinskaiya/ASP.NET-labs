using Microsoft.AspNetCore.Mvc;
using lr9.Models;
using System.Threading.Tasks;

namespace lr9.Views.Shared.Components
{
    public class WeatherViewComponent : ViewComponent
    {
        private readonly WeatherService _weatherService;

        public WeatherViewComponent(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string region)
        {
            var weatherData = await _weatherService.GetWeatherAsync(region);
            return View(weatherData);
        }
    }
}

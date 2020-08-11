using Microsoft.Extensions.Options;
using SmartWeatherBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Weather
{
    public class WeatherClient : BaseRestClient, IOpenWeatherMapClient
    {
        private readonly OpenWeatherConfig config;

        public WeatherClient(IOptions<OpenWeatherConfig> options)
        {
            config = options.Value;
            SetBaseUrl("https://samples.openweathermap.org/");
        }


        public async Task<WeatherData> GetWeatherAsync(double lat, double lon)
        {
            var path = $"/data/2.5/weather?lat={lat}&lon={lon}&appid={config.Token}&units={config.Units}&lang={config.Lang}";
            return await this.Get<WeatherData>(path);
        }
    }
}

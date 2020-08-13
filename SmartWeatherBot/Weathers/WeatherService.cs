using Microsoft.Extensions.Options;
using SmartWeatherBot.Database;
using SmartWeatherBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Weathers
{
    public class WeatherService : BaseRestClient, IWeatherService
    {
        private readonly OpenWeatherConfig config;
        private readonly IWeatherRepository repo;

        public WeatherService(IOptions<OpenWeatherConfig> options, IWeatherRepository repository)
        {
            config = options.Value;
            repo = repository;
            SetBaseUrl("https://api.openweathermap.org/");
        }


        public async Task<Weather> GetWeatherAsync(double lat, double lon)
        {
            Weather data = await repo.GetLastAsync(lat, lon);
            if(data == null)
            {
                var update = await GetWeatherUpdateAsync(lat, lon);
                if(update != null)
                {
                    data = new Weather()
                    {
                        Lat = lat,
                        Lon = lon,
                        Temp = update.State.Temp,
                        TempLike = update.State.FeelsLike,
                        Humidity = update.State.Humidity,
                        Cloudiness = update.Clouds.All,
                        WindSpeed = (int)update.Wind.Speed,
                        Pressure = update.State.Pressure
                    };
                    await repo.InsertAsync(data);
                }
            }
            return data;
        }

        public async Task<WeatherData> GetWeatherUpdateAsync(double lat, double lon)
        {
            var path = $"/data/2.5/weather?lat={lat}&lon={lon}&appid={config.Token}&units={config.Units}&lang={config.Lang}";
            return await this.Get<WeatherData>(path);
        }
    }
}

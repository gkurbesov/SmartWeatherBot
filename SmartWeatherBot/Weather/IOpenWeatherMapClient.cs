using SmartWeatherBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Weather
{
    public interface IOpenWeatherMapClient
    {
        Task<WeatherData> GetWeatherAsync(double lat, double lon);
    }
}

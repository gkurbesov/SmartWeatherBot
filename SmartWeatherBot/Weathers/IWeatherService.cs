using SmartWeatherBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Weathers
{
    public interface IWeatherService
    {
        Task<Weather> GetWeatherAsync(double lat, double lon);
    }
}

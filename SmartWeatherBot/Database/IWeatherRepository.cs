using SmartWeatherBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Database
{
    public interface IWeatherRepository
    {
        Task<IEnumerable<Weather>> GetAllAsync();
        Task<Weather> GetLastAsync(double lat, double lon);
        Task<Weather> InsertAsync(Weather value);
    }
}

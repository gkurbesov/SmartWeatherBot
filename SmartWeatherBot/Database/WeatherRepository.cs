using Microsoft.Extensions.Options;
using SmartWeatherBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Database
{
    public class WeatherRepository : DatabaseSqlite, IWeatherRepository
    {
        public WeatherRepository(IOptions<DatabaseConfig> options)
        {
            SetConfig(options.Value.GetSqlConfig());
        }

        public async Task<IEnumerable<Weather>> GetAllAsync() =>
            await this.GetAllAsync<Weather>();

        public async Task<Weather> GetLast(double lat, double lon) =>
            (await this.QueryAsync<Weather>("SELECT * FROM tbl_weather_cache WHERE location_lat = @Lat AND location_lon = @Lon ORDER BY ID DESC LIMIT 1",
                new { Lat = lat, Lon = lon})).FirstOrDefault();
        

        public async Task<Weather> InsertAsync(Weather value)
        {
            var index = await this.InsertAsIndexAsync(value);
            if(index > 0)
            {
                value.Index = index;
                return value;
            }
            else
            {
                return null;
            }
        }
    }
}

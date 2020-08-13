using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Models
{
    public class WeatherMap : DommelEntityMap<Weather>
    {
        public WeatherMap()
        {
            ToTable("tbl_weather_cache");
            Map(o => o.Index).ToColumn("id").IsKey().IsIdentity();
            Map(o => o.Lat).ToColumn("location_lat");
            Map(o => o.Lon).ToColumn("location_lon");
            Map(o => o.Temp).ToColumn("temp");
            Map(o => o.TempLike).ToColumn("temp_like");
            Map(o => o.Humidity).ToColumn("hum");
            Map(o => o.Cloudiness).ToColumn("cloud");
            Map(o => o.WindSpeed).ToColumn("wind");
            Map(o => o.Pressure).ToColumn("pressure");
            Map(o => o.TimeAdd).ToColumn("time_add");
        }
    }
}

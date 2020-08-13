using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Models
{
    public class Weather
    {
        public long Index { get; set; } = -1;
        public double Lat { get; set; } = 0;
        public double Lon { get; set; } = 0;
        public double Temp { get; set; } = 0;
        public double TempLike { get; set; } = 0;
        public int Humidity { get; set; } = 0;
        public int Cloudiness { get; set; } = 0;
        public int WindSpeed { get; set; } = 0;
        public DateTime TimeAdd { get; set; } = DateTime.Now;
    }
}

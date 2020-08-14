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
        /// <summary>
        /// Фактическая температура
        /// </summary>
        public double Temp { get; set; } = 0;
        /// <summary>
        /// Ощущаемая температура
        /// </summary>
        public double TempLike { get; set; } = 0;
        /// <summary>
        /// Влажность
        /// </summary>
        public int Humidity { get; set; } = 0;
        /// <summary>
        /// Облачность
        /// </summary>
        public int Cloudiness { get; set; } = 0;
        /// <summary>
        /// Скорость ветра
        /// </summary>
        public int WindSpeed { get; set; } = 0;
        /// <summary>
        /// Давление атмосферное
        /// </summary>
        public int Pressure { get; set; } = 0;
        public bool IsRain { get; set; } = false;
        public DateTime TimeAdd { get; set; } = DateTime.Now;
    }
}

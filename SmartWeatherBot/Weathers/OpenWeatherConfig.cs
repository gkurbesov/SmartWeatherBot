using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Weathers
{
    public class OpenWeatherConfig
    {
        public string Token { get; set; } = string.Empty;
        public string Lang { get; set; } = "ru";
        public string Units { get; set; } = "metric";
    }
}

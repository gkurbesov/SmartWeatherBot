using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartWeatherBot.Models
{
    public class WeatherData
    {
        /// <summary>
        /// Коды погодных условий
        /// </summary>
        [JsonProperty("weather")]
        [JsonPropertyName("weather")]
        public List<WeatherDescription> Weathers { get; set; } = new List<WeatherDescription>();
        /// <summary>
        /// Коды погодных условий
        /// </summary>
        [JsonProperty("main")]
        [JsonPropertyName("main")]
        public WeatherState State { get; set; }
        /// <summary>
        /// Ветер
        /// </summary>
        [JsonProperty("wind")]
        [JsonPropertyName("wind")]
        public WindState Wind { get; set; }
        /// <summary>
        /// Облачность
        /// </summary>
        [JsonProperty("clouds")]
        [JsonPropertyName("clouds")]
        public CloudState Clouds { get; set; }

        public class WeatherDescription
        {
            /// <summary>
            ///  Группа погодных параметров (Дождь, Снег, Экстрим и др.)
            /// </summary>
            [JsonProperty("main")]
            [JsonPropertyName("main")]
            public string Main { get; set; }

            /// <summary>
            /// Погодные условия в группе.
            /// </summary>
            [JsonProperty("description")]
            [JsonPropertyName("description")]
            public string Description { get; set; }
        }

        public class WeatherState
        {
            /// <summary>
            /// Температура воздуха
            /// </summary>
            [JsonProperty("temp")]
            [JsonPropertyName("temp")]
            public double Temp { get; set; }

            /// <summary>
            /// Ощущаемая температура воздуха
            /// </summary>
            [JsonProperty("feels_like")]
            [JsonPropertyName("feels_like")]
            public double FeelsLike { get; set; }

            /// <summary>
            /// Минимальная температура на данный момент
            /// </summary>
            [JsonProperty("temp_min")]
            [JsonPropertyName("temp_min")]
            public double TempMin { get; set; }

            /// <summary>
            /// Максимальная температура на данный момент
            /// </summary>
            [JsonProperty("temp_max")]
            [JsonPropertyName("temp_max")]
            public double TempMax { get; set; }

            /// <summary>
            /// Атмосферное давление
            /// </summary>
            [JsonProperty("pressure")]
            [JsonPropertyName("pressure")]
            public int Pressure { get; set; }

            /// <summary>
            /// Влажность
            /// </summary>
            [JsonProperty("humidity")]
            [JsonPropertyName("humidity")]
            public int Humidity { get; set; }
        }

        public class WindState
        {
            /// <summary>
            /// Скорость ветра. 
            /// </summary>
            [JsonProperty("speed")]
            [JsonPropertyName("speed")]
            public double Speed { get; set; }
            /// <summary>
            /// Направление ветра, градусы
            /// </summary>
            [JsonProperty("deg")]
            [JsonPropertyName("deg")]
            public double Deg { get; set; }
        }

        public class CloudState
        {
            /// <summary>
            /// Облачность %
            /// </summary>
            [JsonProperty("all")]
            [JsonPropertyName("all")]
            public int All { get; set; }
        }
    }
}


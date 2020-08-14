using SmartWeatherBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWeatherBot.Messages
{
    public class WeatherMessageBuilder
    {
        public static string Standart(Weather weather)
        {
            return $"Текущая температура: {weather.Temp} \r\n" +
                $"Ощущается как: {weather.TempLike} \r\n" +
                $"Скорость ветра: {weather.WindSpeed} м/с \r\n" +
                $"Влажность: {weather.Humidity} % \r\n" +
                $"Облачность: {weather.Cloudiness} % \r\n" +
                $"Давление: {weather.Pressure} мм/ртс \r\n";
        }

        public static string Smart(Weather weather)
        {
            var hint = string.Empty;

            if (weather.Temp < 3)
                hint = "На улице очень холодно, одевайтесь теплее (зимняя курта и валенка - самое то!) ❄";
            else if (weather.Temp >= 3 && weather.Temp < 10)
                hint = "Рекомендуется надеть теплые вещи и куртку, иначе можно замерзнуть! 🥶";
            else if (weather.Temp >= 10 & weather.Temp < 16)
                hint = weather.WindSpeed >= 4 ? "Думаю стоит одеть ветровку потому, что на улице ветер! 💨" : "Думаю стоит одеть ветровку - так надежнее 👌";
            else if (weather.Temp >= 16 && weather.Temp < 25)
                hint = "Стоит одеть вещи полегче, например футболку 😀";
            else if (weather.Temp >= 25)
            {
                hint = "Стоит одеть вещи полегце, например футболку.";
                if (weather.Cloudiness < 20) hint += "\r\n В такую безоблачную погоду ☀️ рекомендую кепку или панаму 🧢";
            }
            
            if(weather.IsRain)
            {
                hint += "\r\nНа улице дождик, возьмите с собой зонт ☂️, а может даже галоши и дождевик ;-)";
            }
            else if(!weather.IsRain && weather.Cloudiness >= 90)
            {
                hint += "\r\nСлишком облачно. Советую захватить с собой зонт 🌂";
            }

            return Standart(weather) + $"\r\n{hint}";
        }
    }
}

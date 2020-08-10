using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Database
{
    public interface ISqlConfig
    {
        /// <summary>
        /// Получить строку для подключения к БД
        /// </summary>
        /// <returns></returns>
        string GetConnectionString();
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Database
{
    /// <summary>
    /// Интерфейс для работы с базой данных
    /// </summary>
    public interface IMainDatabase
    {
        /// <summary>
        /// Событие об ошибках
        /// </summary>
        event EventHandler<DatabaseErrorArgs> OnDatabaseError;
        void CallError(string msg, string trace = "");
        /// <summary>
        /// Установка новых параметров
        /// </summary>
        /// <param name="value"></param>
        void SetConfig(ISqlConfig value);
        /// <summary>
        /// Получить новый экземпляр подключения
        /// </summary>
        /// <param name="open">открыть соединение?</param>
        /// <returns></returns>
        IDbConnection GetNewConnection(bool open);      
    }
}

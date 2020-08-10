using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Database
{
    public class DatabaseSqlite : IMainDatabase
    {
        /// <summary>
        /// Событие об ошибках при работе с базой данных
        /// </summary>
        public event EventHandler<DatabaseErrorArgs> OnDatabaseError;
        /// <summary>
        /// Настройки подключения к базе данных
        /// </summary>
        protected ISqlConfig config { get; private set; } = null;     
        /// <summary>
        /// Сообщить о возникновении ошибки при работе с базой данных
        /// </summary>
        /// <param name="msg">сообщение об ошибке</param>
        /// <param name="trace">стек вызова ошибки</param>
        public void CallError(string msg, string trace = "")
        {
            Task.Run(() =>
            {
                OnDatabaseError?.Invoke(this, new DatabaseErrorArgs(msg, trace));
            });
        }
        /// <summary>
        /// Получить новый экзепляр подключения к БД с текущими настройками
        /// </summary>
        /// <param name="open">предварительно открыть соединение</param>
        /// <returns></returns>
        public IDbConnection GetNewConnection(bool open)
        {
            try
            {
                var connection = new SQLiteConnection(config.GetConnectionString());
                if (open) connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                CallError(ex.Message, ex.StackTrace);
                return null;
            }
        }
        /// <summary>
        /// Установить новые настройки подключения
        /// </summary>
        /// <param name="value"></param>
        public void SetConfig(ISqlConfig value)
        {
            config = value;
        }        
    }
}

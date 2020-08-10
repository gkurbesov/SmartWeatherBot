using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Database
{
    /// <summary>
    /// Аргумент ошибки
    /// </summary>
    public class DatabaseErrorArgs : EventArgs
    {
        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string Message { get; private set; } = string.Empty;
        /// <summary>
        /// Стек вызова
        /// </summary>
        public string StackTrace { get; private set; } = string.Empty;
        public DatabaseErrorArgs() { }
        public DatabaseErrorArgs(string message, string stackerror = "")
        {
            Message = message;
            StackTrace = stackerror;
        }

        public override string ToString()
        {
            return $"Message: {Message} \r\nStackTrace: {StackTrace}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Database
{
    public class DatabaseConfig
    {
        public string FilePath { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;

        public ISqlConfig GetSqlConfig() =>
            new SQLiteConfig(!string.IsNullOrWhiteSpace(FilePath) ? FilePath : AppDomain.CurrentDomain.BaseDirectory, FileName)
            .SetJournalMode(JournalModeType.MEMORY)
            .SetSynchronous(SynchronousType.OFF)
            .SetAutoVacuum(AutoVacuumType.FULL);
    }
}

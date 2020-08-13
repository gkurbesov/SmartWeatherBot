using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace SmartWeatherBot.Bot
{
    public interface ITelegramBot
    {
        TelegramBotClient Bot { get; set; }
    }
}

using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SmartWeatherBot.Bot
{
    public class TelegramBot : ITelegramBot
    {
        public TelegramBotClient Bot { get; set; }

        public TelegramBot(IOptions<TelegramConfig> options)
        {
            try
            {
                Bot = new TelegramBotClient(options.Value.Token);
                ClietnSetCommand();
            }
            catch (Exception ex)
            {
                Bot = null;
            }
        }

        private void ClietnSetCommand()
        {
            var commands = new BotCommand[]
            {
                 new BotCommand(){Command = "/weather", Description = "Получить текущую температуру"},
                 new BotCommand(){Command = "/location", Description = "Изменить гео-локацию для получения прогноза"},
                 new BotCommand(){Command = "/update", Description = "Сообщать свежий прогноз погоды"},
            };
            Bot?.SetMyCommandsAsync(commands);
        }

    }
}

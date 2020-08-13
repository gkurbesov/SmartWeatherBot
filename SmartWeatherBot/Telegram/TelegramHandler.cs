using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace SmartWeatherBot.Telegram
{
    public class TelegramHandler
    {
        private readonly ITelegramBot _bot;

        public TelegramHandler(ITelegramBot telegramBot)
        {
            _bot = telegramBot;
            if (_bot.Bot != null)
                InitHandler();
        }

        private void InitHandler()
        {
            _bot.Bot.OnMessage += (s, e) => OnMessage(e.Message);
            _bot.Bot.StartReceiving();
        }

        private void OnMessage(Message Message)
        {
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace SmartWeatherBot.Bot
{
    public abstract class TelegramHandler
    {
        protected readonly ITelegramBot _bot;

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
            switch (Message.Type)
            {
                case Telegram.Bot.Types.Enums.MessageType.Text:
                    var action = (Message.Text.Split(' ').First()) switch
                    {
                        _ => OnReceiveUnknown(Message.Chat.Id)
                    };
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Location:

                    break;
                default:

                    break;
            }
        }

        protected abstract Task OnReceiveStart(long chatId);
        protected abstract Task OnReceiveLocation(long chatId);
        protected abstract Task OnReceiveGetWeather(long chatId);
        protected abstract Task OnReceiveUpdateRequest(long chatId);
        protected abstract Task OnReceiveUnknown(long chatId);
        protected abstract Task SendAsync(long chatId, string message);
    }
}

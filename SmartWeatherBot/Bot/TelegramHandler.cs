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
            CheckUser(Message.Chat.Id).Wait();
            switch (Message.Type)
            {
                case Telegram.Bot.Types.Enums.MessageType.Text:
                    var action = (Message.Text.Split(' ').First()) switch
                    {
                        "/start" => OnReceiveStart(Message.Chat.Id, Message.Chat.Username),
                        "/weather" => OnReceiveWeather(Message.Chat.Id),
                        "/location" => OnReceiveLocation(Message.Chat.Id),
                        "/update" => OnReceiveUpdateRequest(Message.Chat.Id),
                        _ => OnReceiveUnknown(Message.Chat.Id)
                    };
                    action.Wait();
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Location:

                    break;
                default:
                    OnReceiveUnknown(Message.Chat.Id).Start();
                    break;
            }
        }

        protected abstract Task CheckUser(long chatId);
        protected abstract Task OnReceiveStart(long chatId, string username);
        protected abstract Task OnReceiveLocation(long chatId);
        protected abstract Task OnReceiveWeather(long chatId);
        protected abstract Task OnReceiveUpdateRequest(long chatId);
        protected abstract Task OnReceiveUnknown(long chatId);
        protected abstract Task SendAsync(long chatId, string message);
    }
}

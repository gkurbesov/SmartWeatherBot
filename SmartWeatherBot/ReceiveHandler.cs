using SmartWeatherBot.Bot;
using SmartWeatherBot.Database;
using SmartWeatherBot.Weathers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot
{
    public class ReceiveHandler : TelegramHandler
    {
        IWeatherService _weather;
        IUserRepository _users;

        public ReceiveHandler(ITelegramBot telegramBot, 
            IWeatherService weatherService,
            IUserRepository repository) : base(telegramBot)
        {
            _weather = weatherService;
            _users = repository;
        }

        protected override Task OnReceiveGetWeather(long chatId)
        {
            throw new NotImplementedException();
        }

        protected override Task OnReceiveLocation(long chatId)
        {
            throw new NotImplementedException();
        }

        protected override Task OnReceiveStart(long chatId)
        {
            throw new NotImplementedException();
        }

        protected override Task OnReceiveUnknown(long chatId)
        {
            throw new NotImplementedException();
        }

        protected override Task OnReceiveUpdateRequest(long chatId)
        {
            throw new NotImplementedException();
        }

        protected override Task SendAsync(long chatId, string message)
        {
            throw new NotImplementedException();
        }
    }
}

using SmartWeatherBot.Bot;
using SmartWeatherBot.Database;
using SmartWeatherBot.Models;
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

        protected override async Task CheckUser(long chatId)
        {
            var user = await _users.GetUserTelegram(chatId);
            if(user == null)
            {
                user = new User()
                {
                    TelegramID = chatId
                };
                await _users.InsertAsync(user);
            }
        }

        protected override async Task OnReceiveWeather(long chatId)
        {
            var user = await _users.GetUserTelegram(chatId);
            if(user != null)
            {
                if (user.IsValidLocation())
                {
                    var weatherStatus = await _weather.GetWeatherAsync(user.Lat, user.Lon);
                    if(weatherStatus != null)
                    {
                        await SendAsync(chatId, $"Текущая температура: {weatherStatus.Temp}\r\nОщущается как: {weatherStatus.TempLike}");
                    }
                    else
                    {
                        await SendAsync(chatId, $"Что то пошло не так, попробуйте позже");
                    }
                }
                else
                {
                    await SendAsync(chatId, "к сожалению ваша геолокация неизвестна. Сообщите мне ваши координаты и тогда я смогу вам сообщить погоду!");
                }
            }
        }

        protected override Task OnReceiveLocation(long chatId)
        {
            throw new NotImplementedException();
        }

        protected override async Task OnReceiveStart(long chatId, string username)
        {
            await SendAsync(chatId, $"Приветствую тебя, {username}!\r\n Я умный погодный Telegram бот. \r\nЯ подскажу тебе погоду по твоему местоположению!");
        }

        protected override async Task OnReceiveUnknown(long chatId)
        {
            await SendAsync(chatId, "Я не понимаю тебя, человек");
        }

        protected override Task OnReceiveUpdateRequest(long chatId)
        {
            throw new NotImplementedException();
        }

        protected override async Task SendAsync(long chatId, string message)
        {
            await _bot.Bot.SendTextMessageAsync(chatId, message);
        }
    }
}

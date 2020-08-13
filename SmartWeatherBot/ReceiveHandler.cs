using SmartWeatherBot.Bot;
using SmartWeatherBot.Database;
using SmartWeatherBot.Models;
using SmartWeatherBot.Weathers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

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
            if (user == null)
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
            if (user != null)
            {
                if (user.IsValidLocation())
                {
                    var weatherStatus = await _weather.GetWeatherAsync(user.Lat, user.Lon);
                    if (weatherStatus != null)
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

        protected override async Task OnReceiveLocation(long chatId)
        {
            var keyboard = new ReplyKeyboardMarkup(new[]
                {
                    KeyboardButton.WithRequestLocation("Location")
                }, false, true);
            var msg = await _bot.Bot?.SendTextMessageAsync(
                chatId: chatId,
                text: "Скорее жми кнопку и я получу твои координаты!",
                replyMarkup: keyboard
            );
            _ = Task.Run(async () =>
            {
                await Task.Delay(5000);
                _ = _bot.Bot.DeleteMessageAsync(chatId, msg.MessageId);
            });
        }


        protected override async Task OnReceiveSetLocation(long chatId, double lat, double lon)
        {
            var user = await _users.GetUserTelegram(chatId);
            if (user != null)
            {
                user.Lat = lat;
                user.Lon = lon;
                var result = await _users.UpdateUserAsync(user);
                if (result)
                {
                    await SendAsync(chatId, $"Отлично, теперь я могу сообщать погоду!");
                }
                else
                {
                    await SendAsync(chatId, $"Что то пошло не так, попробуйте позже");
                }
            }
        }

        protected override async Task OnReceiveStart(long chatId, string username)
        {
            await SendAsync(chatId, $"Приветствую тебя, {username}!\r\n Я умный погодный Telegram бот. \r\nЯ подскажу тебе погоду по твоему местоположению!");
        }

        protected override async Task OnReceiveUnknown(long chatId)
        {
            await SendAsync(chatId, "Я не понимаю тебя, человек");
        }

        protected override async Task OnReceiveUpdateRequest(long chatId)
        {
            await SendAsync(chatId, "Пока я не могу присылать ежедневный прогноз погоды. Попробуй позже :)");
        }

        protected override async Task SendAsync(long chatId, string message)
        {
            try
            {
                await _bot.Bot.SendTextMessageAsync(
                    chatId: chatId,
                    text: message,
                    replyMarkup: null
                    );
            }
            catch { }
        }
    }
}

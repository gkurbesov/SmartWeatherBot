using Microsoft.Extensions.Hosting;
using SmartWeatherBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartWeatherBot
{
    public class HostService : BackgroundService
    {
        private readonly TelegramHandler _telegram;


        public HostService(TelegramHandler telegramHandler)
        {
            _telegram = telegramHandler;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}

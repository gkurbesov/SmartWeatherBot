using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmartWeatherBot.Database;
using SmartWeatherBot.Models;
using SmartWeatherBot.Bot;
using SmartWeatherBot.Weathers;
using Microsoft.AspNetCore.Http;

namespace SmartWeatherBot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new UserMap());
                config.AddMap(new WeatherMap());
                config.ForDommel();
            });

            services.Configure<DatabaseConfig>(Configuration.GetSection("Database"));
            services.Configure<TelegramConfig>(Configuration.GetSection("Telegram"));
            services.Configure<OpenWeatherConfig>(Configuration.GetSection("OpenWeather"));

            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IWeatherRepository, WeatherRepository>();

            services.AddSingleton<ITelegramBot, TelegramBot>();
            services.AddSingleton<TelegramHandler, ReceiveHandler>();
            services.AddTransient<IWeatherService, WeatherService>();

            services.AddHostedService<HostService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("SmartWetherBot is running!");
                });
            });
        }
    }
}

﻿using SmartWeatherBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Database
{
    public interface IUserRepository
    {
        Task<User> GetUser(int index);
        Task<User> GetUserTelegram(long telegram_id);
        Task<User> InsertAsync(User value);
        Task<bool> UpdateUserAsync(User value);
        Task<bool> DeleteAsync(int index);
    }
}

using SmartWeatherBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Database
{
    public interface IUserRepository
    {
        Task<User> GetUser(int index);
        Task<User> GetUserTelegram(int telegram_id);
        Task<User> InsertAsync(User value);
        Task<bool> UpdateAsync(User value);
        Task<bool> DeleteAsync(int index);
    }
}

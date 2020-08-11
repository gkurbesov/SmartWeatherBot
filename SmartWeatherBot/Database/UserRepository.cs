using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Microsoft.Extensions.Options;
using SmartWeatherBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Database
{
    public class UserRepository : DatabaseSqlite, IUserRepository
    {
        public UserRepository(IOptions<DatabaseConfig> options)
        {
            SetConfig(options.Value.GetSqlConfig());
        }

        public async Task<User> GetUser(int index) =>
            await this.GetAsync<User>(index);

        public async Task<User> GetUserTelegram(int telegram_id) =>
            await this.FirstAsync<User>(o => o.TelegramID == telegram_id);

        public async Task<User> InsertAsync(User value)
        {
            var index = await this.InsertAsIndexAsync(value);
            if (index > 0)
            {
                value.Index = index;
                return value;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(User value) =>
            await this.UpdateAsync(value);

        public async Task<bool> DeleteAsync(int index) =>
            await this.DeleteAsync<User>(o => o.Index == index);

    }
}

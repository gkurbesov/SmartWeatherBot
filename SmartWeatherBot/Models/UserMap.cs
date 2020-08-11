using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Models
{
    public class UserMap : DommelEntityMap<User>
    {
        public UserMap()
        {
            ToTable("tbl_users");
            Map(o => o.Index).ToColumn("id").IsKey().IsIdentity();
            Map(o => o.TelegramID).ToColumn("telegram_id");
            Map(o => o.Lat).ToColumn("location_lat");
            Map(o => o.Lon).ToColumn("location_lon");
            Map(o => o.SendChange).ToColumn("send_change");
            Map(o => o.TimeStart).ToColumn("time_start");
        }
    }
}

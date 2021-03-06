﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWeatherBot.Models
{
    public class User
    {
        public long Index { get; set; } = -1;
        public long TelegramID { get; set; } = -1;
        public double Lat { get; set; } = 55.753215;
        public double Lon { get; set; } = 37.622504;
        public bool SendChange { get; set; } = false;
        public DateTime TimeStart { get; set; } = DateTime.Now;

        public bool IsValidLocation() => Lat != 0 && Lon != 0;
    }
}

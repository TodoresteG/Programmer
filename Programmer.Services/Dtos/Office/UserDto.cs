using System;
using System.Collections.Generic;

namespace Programmer.Services.Dtos.Office
{
    public class UserDto
    {
        public long Xp { get; set; }

        public long XpForNextLevel { get; set; }

        public int Level { get; set; }

        public int Energy { get; set; }

        public decimal Money { get; set; }

        public int Bitcoins { get; set; }

        public TimeSpan? TimeRemaining { get; set; }

        public IDictionary<string, double?> UserStats { get; set; }
    }
}

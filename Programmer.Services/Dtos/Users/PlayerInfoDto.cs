namespace Programmer.Services.Dtos.Users
{
    using System;

    public class PlayerInfoDto
    {
        public int Level { get; set; }

        public long Xp { get; set; }

        public long XpForNextLevel { get; set; }

        public decimal Money { get; set; }

        public int Bitcoins { get; set; }

        public int Energy { get; set; }

        public TimeSpan? TimeRemaining { get; set; }
    }
}

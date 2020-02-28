namespace Programmer.App.Models.Users
{
    using System;

    public class PlayerInfoViewModel
    {
        public int Level { get; set; }

        public long Xp { get; set; }

        public long XpForNextLevel { get; set; }

        public decimal Money { get; set; }

        public int Bitcoins { get; set; }

        public int Energy { get; set; }

        public TimeSpan? TimeRemaining { get; set; }

        public bool IsActive { get; set; }
    }
}

namespace Programmer.App.Models.Office
{
    using System;
    using System.Collections.Generic;

    public class OfficeViewModel
    {
        public long Xp { get; set; }

        public long XpForNextLevel { get; set; }

        public int Level { get; set; }

        public int Energy { get; set; }

        public decimal Money { get; set; }

        public int Bitcoins { get; set; }

        public DateTime? TimeRemaining { get; set; }

        public IDictionary<string, double?> UserStats { get; set; }
    }
}

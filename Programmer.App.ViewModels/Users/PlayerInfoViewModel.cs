namespace Programmer.App.ViewModels.Users
{
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;
    using System;

    public class PlayerInfoViewModel : IMapFrom<ProgrammerUser>
    {
        public int Level { get; set; }

        public long Xp { get; set; }

        public long XpForNextLevel { get; set; }

        public decimal Money { get; set; }

        public int Bitcoins { get; set; }

        public int Energy { get; set; }

        public DateTime? TimeRemaining { get; set; }

        public bool IsActive { get; set; }
    }
}

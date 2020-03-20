namespace Programmer.Data.Models
{
    using Programmer.Data.Common.Models;

    using System.Collections.Generic;

    public class Event : BaseDeletableModel<int>
    {
        public Event()
        {
        }

        public string Name { get; set; }

        public int XpReward { get; set; }

        public string ProgrammerUserId { get; set; }

        public ProgrammerUser Player { get; set; }
    }
}

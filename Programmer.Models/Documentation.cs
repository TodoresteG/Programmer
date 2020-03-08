namespace Programmer.Models
{
    using Programmer.Data.Common.Models;

    using System.Collections.Generic;

    public class Documentation : BaseDeletableModel<int>
    {
        public Documentation()
        {
            this.Categories = new HashSet<AdditionalActivityCategory>();
        }

        public string Name { get; set; }

        public int XpReward { get; set; }

        public string ProgrammerUserId { get; set; }

        public ProgrammerUser Player { get; set; }

        public ICollection<AdditionalActivityCategory> Categories { get; set; }
    }
}

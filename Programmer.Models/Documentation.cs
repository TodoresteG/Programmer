namespace Programmer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Documentation
    {
        public Documentation()
        {
            this.Categories = new HashSet<AdditionalActivityCategory>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int XpReward { get; set; }

        public string ProgrammerUserId { get; set; }

        public ProgrammerUser Player { get; set; }

        public ICollection<AdditionalActivityCategory> Categories { get; set; }
    }
}

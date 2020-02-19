namespace Programmer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Event
    {
        public Event()
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

namespace Programmer.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AdditionalActivityCategory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int RequiredEnergy { get; set; }

        public double HardSkillReward { get; set; }

        public double SoftSkillReward { get; set; }

        public DateTime BaseTimeNeeded { get; set; }

        public int DocumentationId { get; set; }

        public Documentation Documentation { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }
    }
}

namespace Programmer.Models
{
    using Programmer.Data.Common.Models;

    public class AdditionalActivityCategory : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int RequiredEnergy { get; set; }

        public double HardSkillReward { get; set; }

        public double SoftSkillReward { get; set; }

        public int DocumentationId { get; set; }

        public Documentation Documentation { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }
    }
}

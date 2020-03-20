namespace Programmer.App.ViewModels.Documentations
{
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;

    public class DocumentationIndexViewModel : IMapFrom<Documentation>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int XpReward { get; set; }

        public int RequiredEnergy { get; set; }

        public double HardSkillReward { get; set; }

        public string HardSkillName { get; set; }
    }
}

namespace Programmer.Data.Models
{
    using Programmer.Data.Common.Models;

    using System.Collections.Generic;

    public class Documentation : BaseDeletableModel<int>
    {
        public Documentation()
        {
            this.UserDocumentations = new HashSet<UserDocumentation>();
        }

        public string Name { get; set; }

        public int XpReward { get; set; }

        public int RequiredEnergy { get; set; }

        public double HardSkillReward { get; set; }

        public string HardSkillName { get; set; }

        public ICollection<UserDocumentation> UserDocumentations { get; set; }
    }
}

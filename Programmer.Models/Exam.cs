namespace Programmer.Data.Models
{
    using Programmer.Data.Common.Models;

    public class Exam : BaseDeletableModel<int>
    {
        public int RequiredEnergy { get; set; }

        public double RequiredHardSkill { get; set; }

        public string RequiredHardSkillName { get; set; }

        public double RequiredCodingSkill { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}

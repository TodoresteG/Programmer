namespace Programmer.App.ViewModels.Courses
{
    using System.Collections.Generic;

    public class AdministrationCreateCourseInputModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<string> HardSkillName { get; set; }

        public double HardSkillReward { get; set; }

        public IEnumerable<string> SoftSkillName { get; set; }

        public double SoftSkillReward { get; set; }

        public int RequiredEnergy { get; set; }

        public int XpReward { get; set; }
    }
}

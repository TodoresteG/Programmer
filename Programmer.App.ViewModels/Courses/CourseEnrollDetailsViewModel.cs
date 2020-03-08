namespace Programmer.App.ViewModels.Courses
{
    using Programmer.App.ViewModels.Lectures;
    using System.Collections.Generic;

    public class CourseEnrollDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double HardSkillReward { get; set; }

        public string HardSkillName { get; set; }

        public double CodingSkillReward { get; set; }

        public double SoftSkillReward { get; set; }

        public string SoftSkillName { get; set; }

        public bool IsPreviousCompleted { get; set; }

        public decimal Price { get; set; }

        public IList<LectureCourseEnrollViewModel> Lectures { get; set; }
    }
}

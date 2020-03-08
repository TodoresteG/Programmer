namespace Programmer.App.ViewModels.Courses
{
    using Programmer.App.ViewModels.Lectures;
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;
    using System.Collections.Generic;

    public class CourseEnrollDetailsViewModel : IMapFrom<Course>
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

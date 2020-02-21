namespace Programmer.Services.Dtos.Courses
{
    using Programmer.Services.Dtos.Lectures;
    using System.Collections.Generic;

    public class CourseDetailsDto
    {
        public string Name { get; set; }

        public double CSharpSkillReward { get; set; }

        public double CodingSkillReward { get; set; }

        public double ProblemSolvingReward { get; set; }

        public decimal Price { get; set; }

        public IList<LectureCourseDto> Lectures { get; set; }
    }
}

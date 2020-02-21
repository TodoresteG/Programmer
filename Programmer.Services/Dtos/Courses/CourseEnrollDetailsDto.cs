namespace Programmer.Services.Dtos.Courses
{
    using Programmer.Services.Dtos.Lectures;
    using System.Collections.Generic;

    public class CourseEnrollDetailsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double CSharpSkillReward { get; set; }

        public double CodingSkillReward { get; set; }

        public double ProblemSolvingReward { get; set; }

        public decimal Price { get; set; }

        public IList<LectureCourseEnrollDto> Lectures { get; set; }
    }
}

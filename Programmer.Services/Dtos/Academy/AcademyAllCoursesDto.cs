namespace Programmer.Services.Dtos.Academy
{
    using System.Collections.Generic;

    public class AcademyAllCoursesDto
    {
        public IList<AcademyCourseDto> AllCourses { get; set; }

        public IEnumerable<AcademyEnrolledCourseDto> EnrolledCourses { get; set; }

        public IEnumerable<AcademyCompletedCourseDto> CompletedCourses { get; set; }
    }
}

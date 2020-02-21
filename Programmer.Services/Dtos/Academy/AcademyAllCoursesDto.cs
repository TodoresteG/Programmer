namespace Programmer.Services.Dtos.Academy
{
    using System.Collections.Generic;

    public class AcademyAllCoursesDto
    {
        public IEnumerable<AcademyCourseDto> Courses { get; set; }
    }
}

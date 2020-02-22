namespace Programmer.Services.Dtos.Courses
{
    using Programmer.Services.Dtos.Lectures;
    using System.Collections.Generic;

    public class CourseDetailsDto
    {
        public string Name { get; set; }

        public IList<LectureCourseDetailsDto> Lectures { get; set; }
    }
}

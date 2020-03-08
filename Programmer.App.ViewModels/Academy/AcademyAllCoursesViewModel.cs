namespace Programmer.App.ViewModels.Academy
{
    using System.Collections.Generic;

    public class AcademyAllCoursesViewModel
    {
        public IEnumerable<AcademyCourseViewModel> AllCourses { get; set; }

        public IEnumerable<AcademyEnrolledCourseViewModel> EnrolledCourses { get; set; }

        public IEnumerable<AcademyCompletedCourseViewModel> CompletedCourses { get; set; }
    }
}

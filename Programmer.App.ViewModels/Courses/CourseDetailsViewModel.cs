namespace Programmer.App.ViewModels.Courses
{
    using Programmer.App.ViewModels.Lectures;
    using System.Collections.Generic;

    public class CourseDetailsViewModel
    {
        public string Name { get; set; }

        public IList<LectureCourseDetailsViewModel> Lectures { get; set; }
    }
}

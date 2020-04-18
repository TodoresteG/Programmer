namespace Programmer.App.ViewModels.Courses
{
    using System.Collections.Generic;
    using Programmer.App.ViewModels.Exams;
    using Programmer.App.ViewModels.Lectures;

    public class AdministrationCourseInfoViewModel
    {
        public IEnumerable<AdministrationLectureViewModel> Lectures { get; set; }

        public AdministrationExamViewModel Exam { get; set; }
    }
}

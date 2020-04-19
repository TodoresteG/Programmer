namespace Programmer.Services
{
    using Programmer.App.ViewModels.Academy;
    using Programmer.App.ViewModels.Courses;

    public interface IAcademyService
    {
        AcademyAllCoursesViewModel GetAllCourses(string userId);

        AdministrationAcademyAllCoursesViewModel GetAllCoursesForAdmin();

        AdministrationCourseInfoViewModel CourseInfo(int courseId);

        AdministrationCreateCourseInputModel GetSkillsForDropdowns();
    }
}

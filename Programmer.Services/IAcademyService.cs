namespace Programmer.Services
{
    using Programmer.App.ViewModels.Academy;

    public interface IAcademyService
    {
        AcademyAllCoursesViewModel GetAllCourses(string userId);
    }
}

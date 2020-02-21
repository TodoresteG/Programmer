namespace Programmer.Services
{
    using Programmer.Services.Dtos.Academy;

    public interface IAcademyService
    {
        AcademyAllCoursesDto GetAllCourses(string userId);
    }
}

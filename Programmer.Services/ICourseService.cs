namespace Programmer.Services
{
    using Programmer.Services.Dtos.Courses;

    public interface ICourseService
    {
        CourseEnrollDetailsDto GetCourseEnrollDetails(int id);

        CourseDetailsDto GetCourseDetails(int id);

        bool EnrollUserToCourse(int id, string userId);

        bool IsEnrolled(int id, string userId);
    }
}

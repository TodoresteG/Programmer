namespace Programmer.Services
{
    using Programmer.Services.Dtos.Courses;

    public interface ICourseService
    {
        CourseEnrollDetailsDto GetCourseEnrollDetails(int id, string userId);

        CourseDetailsDto GetCourseDetails(int id, string userId);

        bool EnrollUserToCourse(int id, string userId);

        bool IsEnrolled(int id, string userId);

        bool IsPreviousCompleted(int id, string userId);
    }
}

namespace Programmer.Services
{
    using Programmer.App.ViewModels.Courses;

    public interface ICourseService
    {
        CourseEnrollDetailsViewModel GetCourseEnrollDetails(int id, string userId);

        CourseDetailsViewModel GetCourseDetails(int id, string userId);

        bool EnrollUserToCourse(int id, string userId);

        bool IsEnrolled(int id, string userId);

        bool IsPreviousCompleted(int id, string userId);
    }
}

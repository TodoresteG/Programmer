namespace Programmer.Services
{
    using Programmer.Services.Dtos.Courses;

    public interface ICourseService
    {
        CourseEnrollDetailsDto GetCourseEnrollDetails(int id);

        CourseDetailsDto GetCourseDetails(int id);

        void EnrollUserToCourse(int id, string userId);
    }
}

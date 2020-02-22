namespace Programmer.Services
{
    using Programmer.Data;
    using Programmer.Services.Dtos.Academy;
    using Programmer.Services.Dtos.Lectures;
    using System.Linq;

    public class AcademyService : IAcademyService
    {
        private readonly ProgrammerDbContext context;

        public AcademyService(ProgrammerDbContext context)
        {
            this.context = context;
        }

        public AcademyAllCoursesDto GetAllCourses(string userId)
        {
            var allCourses = this.context.Courses
                .Select(c => new AcademyCourseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    IsCompleted = c.Users.Select(u => u.IsCompleted).FirstOrDefault(),
                    IsEnrolled = c.Users.Select(u => u.IsEnrolled).FirstOrDefault(),
                })
                .ToList();

            var enrolledCourses = this.context.UserCourses
                .Where(c => c.ProgrammerUserId == userId && c.IsEnrolled == true)
                .Select(c => new AcademyEnrolledCourseDto
                {
                    Id = c.CourseId,
                    Name = c.Course.Name,
                })
                .ToList();

            var completedCourses = this.context.UserCourses
                .Where(c => c.IsCompleted == true)
                .Select(c => new AcademyCompletedCourseDto
                {
                    Name = c.Course.Name,
                })
                .ToList();

            var dto = new AcademyAllCoursesDto
            {
                AllCourses = allCourses,
                EnrolledCourses = enrolledCourses,
                CompletedCourses = completedCourses,
            };

            return dto;
        }
    }
}

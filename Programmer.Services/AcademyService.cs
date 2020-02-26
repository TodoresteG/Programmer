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
                    IsEnrolled = c.Users.Where(u => u.ProgrammerUserId == userId).Select(u => u.IsEnrolled).FirstOrDefault(),
                })
                .ToList();

            var enrolledCourses = this.context.UserCourses
                .Where(u => u.IsEnrolled == true && u.ProgrammerUserId == userId)
                .Select(c => new AcademyEnrolledCourseDto
                {
                    Id = c.CourseId,
                    Name = c.Course.Name,
                })
                .ToList();

            var completedCourses = this.context.UserCourses
                .Where(c => c.IsCompleted == true && c.ProgrammerUserId == userId)
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

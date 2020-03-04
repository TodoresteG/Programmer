namespace Programmer.Services
{
    using Programmer.Data;
    using Programmer.Services.Dtos.Academy;
    using Programmer.Services.Dtos.Lectures;
    using Programmer.Services.Dtos.Users;
    using Programmer.Services.Extensions.Courses;
    using System.Collections.Generic;
    using System.Linq;

    public class AcademyService : IAcademyService
    {
        private readonly ProgrammerDbContext context;

        public AcademyService(ProgrammerDbContext context)
        {
            this.context = context;
        }

        private IEnumerable<bool> CheckCoursesRequiredSkills(string userId)
        {
            var user = this.context.Users
                .Where(u => u.Id == userId)
                .Select(u => new UserStatsDto
                {
                    AbstractThinking = u.AbstractThinking,
                    Algorithms = u.Algorithms,
                    AspNetCore = u.AspNetCore,
                    CSharp = u.CSharp,
                    Bitcoins = u.Bitcoins,
                    Creativity = u.Creativity,
                    Coding = u.Coding,
                    Css = u.Css,
                    Curiosity = u.Curiosity,
                    DatabasesAndSQL = u.DatabasesAndSQL,
                    DataStructures = u.DataStructures,
                    EfCore = u.EfCore,
                    Energy = u.Energy,
                    Html = u.Html,
                    Level = u.Level,
                    Money = u.Money,
                    NodeJs = u.NodeJs,
                    ProblemSolving = u.ProblemSolving,
                    React = u.React,
                    Testing = u.Testing,
                    VanillaJavaScript = u.VanillaJavaScript,
                    Xp = u.Xp,
                })
                .FirstOrDefault();

            return CourseExtension.CheckCourses(user);
        }

        // TODO: Make this work with the method above
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

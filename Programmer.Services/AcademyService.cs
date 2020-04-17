namespace Programmer.Services
{
    using Programmer.App.ViewModels.Academy;
    using Programmer.Data;
    using Programmer.Services.Mapping;
    using Programmer.Services.Dtos;
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
                .Select(u => new UserStatsViewModel
                {
                    AbstractThinking = u.AbstractThinking,
                    Algorithms = u.Algorithms,
                    AspNetCore = u.AspNetCore,
                    Bitcoins = u.Bitcoins,
                    Coding = u.Coding,
                    Creativity = u.Creativity,
                    CSharp = u.CSharp,
                    Css = u.Css,
                    Curiosity = u.Curiosity,
                    DatabasesAndSQL = u.DatabasesAndSQL,
                    DataStructures = u.DataStructures,
                    EfCore = u.EfCore,
                    Energy = u.Energy,
                    Html = u.Html,
                    IsActive = u.IsActive,
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
        public AcademyAllCoursesViewModel GetAllCourses(string userId)
        {
            var test = this.CheckCoursesRequiredSkills(userId);

            // really bad query can't figure other way. It works for now
            var allCourses = this.context.Courses
                .Select(c => new AcademyCourseViewModel 
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    IsCompleted = c.Users.Where(uc => uc.ProgrammerUserId == userId).Select(uc => uc.IsCompleted).FirstOrDefault(),
                    IsEnrolled = c.Users.Where(uc => uc.ProgrammerUserId == userId).Select(uc => uc.IsEnrolled).FirstOrDefault(),
                })
                .ToList();

            var enrolledCourses = this.context.UserCourses
                .Where(u => u.IsEnrolled == true && u.ProgrammerUserId == userId)
                .To<AcademyEnrolledCourseViewModel>()
                .ToList();

            var completedCourses = this.context.UserCourses
                .Where(c => c.IsCompleted == true && c.ProgrammerUserId == userId)
                .To<AcademyCompletedCourseViewModel>()
                .ToList();

            var dto = new AcademyAllCoursesViewModel
            {
                AllCourses = allCourses,
                EnrolledCourses = enrolledCourses,
                CompletedCourses = completedCourses,
            };

            return dto;
        }
    }
}

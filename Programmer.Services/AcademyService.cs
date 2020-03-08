namespace Programmer.Services
{
    using Programmer.App.ViewModels.Academy;
    using Programmer.Data;
    using Programmer.Services.Mapping;
    using Programmer.Services.Dtos;
    using Programmer.Services.Extensions.Courses;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

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
                .To<UserStatsDto>()
                .FirstOrDefault();

            return CourseExtension.CheckCourses(user);
        }

        // TODO: Make this work with the method above
        public AcademyAllCoursesViewModel GetAllCourses(string userId)
        {
            var allCourses = this.context.Courses
                .Include(c => c.Users)
                .To<AcademyCourseViewModel>()
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

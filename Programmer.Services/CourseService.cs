namespace Programmer.Services
{
    using Programmer.Data;
    using Programmer.Models;
    using Programmer.Services.Dtos.Courses;
    using Programmer.Services.Dtos.Lectures;
    using System.Linq;

    public class CourseService : ICourseService
    {
        private readonly ProgrammerDbContext context;

        public CourseService(ProgrammerDbContext context)
        {
            this.context = context;
        }

        // TODO: This is a slow method
        public bool EnrollUserToCourse(int id, string userId)
        {
            UserCourse userCourse = new UserCourse
            {
                ProgrammerUserId = userId,
                CourseId = id,
                IsEnrolled = true,
            };

            this.context.UserCourses.Add(userCourse);

            var course = this.context.Courses.Find(id);

            var user = this.context.Users.Find(userId);

            if (user.Money < course.Price)
            {
                return false;
            }

            user.Money -= userCourse.Course.Price;

            this.context.Update(user);
            this.context.SaveChanges();

            return true;
        }

        public CourseDetailsDto GetCourseDetails(int id)
        {
            var course = this.context.Courses
                .Where(c => c.Id == id)
                .Select(c => new CourseDetailsDto
                {
                    Name = c.Name,
                    Lectures = c.Lectures.Select(l => new LectureCourseDetailsDto
                    {
                        Id = l.Id,
                        Name = l.Name,
                        IsCompleted = l.IsCompleted,
                    }).ToList()
                })
                .FirstOrDefault();

            return course;
        }

        public CourseEnrollDetailsDto GetCourseEnrollDetails(int id)
        {
            var course = this.context.Courses
                .Where(c => c.Id == id)
                .Select(c => new CourseEnrollDetailsDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    CSharpSkillReward = c.HardSkillReward * c.Lectures.Count() * 2,
                    CodingSkillReward = c.SoftSkillReward * c.Lectures.Count(),
                    ProblemSolvingReward = c.SoftSkillReward * c.Lectures.Count(),
                    Lectures = c.Lectures.Select(l => new LectureCourseEnrollDto
                    {
                        Name = l.Name,
                    }).ToList()
                })
                .FirstOrDefault();

            return course;
        }

        public bool IsEnrolled(int id, string userId)
        {
            return this.context.UserCourses
                .Where(c => c.CourseId == id && c.ProgrammerUserId == userId)
                .Select(c => c.IsEnrolled)
                .FirstOrDefault();
        }
    }
}

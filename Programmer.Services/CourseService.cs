namespace Programmer.Services
{
    using Programmer.Data;
    using Programmer.Models;
    using Programmer.Services.Dtos.Courses;
    using Programmer.Services.Dtos.Lectures;
    using System.Collections.Generic;
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

            List<UserLecture> userLectures = this.context.Lectures
                .Where(l => l.CourseId == id)
                .Select(l => new UserLecture
                {
                    ProgrammerUserId = userId,
                    LectureId = l.Id,
                })
                .ToList();

            this.context.UserCourses.Add(userCourse);
            this.context.UserLectures.AddRange(userLectures);

            var course = this.context.Courses
                .Where(c => c.Id == id)
                .Select(c => new Course
                {
                    Price = c.Price,
                })
                .FirstOrDefault();

            var user = this.context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefault();

            if (user.Money < course.Price)
            {
                return false;
            }

            user.Money -= course.Price;

            this.context.Users.Update(user);
            this.context.SaveChanges();
            return true;
        }

        public CourseDetailsDto GetCourseDetails(int id, string userId)
        {
            var course = this.context.UserCourses
                .Where(c => c.CourseId == id && c.ProgrammerUserId == userId)
                .Select(c => new CourseDetailsDto
                {
                    Name = c.Course.Name,
                    Lectures = c.Course.Lectures.SelectMany(c => c.UserLectures)
                    .Where(ul => ul.ProgrammerUserId == userId)
                    .Select(ul => new LectureCourseDetailsDto
                    {
                        Id = ul.LectureId,
                        Name = ul.Lecture.Name,
                        IsCompleted = ul.IsCompleted,
                    })
                    .ToList()
                })
                .FirstOrDefault();

            return course;
        }

        public CourseEnrollDetailsDto GetCourseEnrollDetails(int id, string userId)
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

            course.IsPreviousCompleted = this.IsPreviousCompleted(id, userId);

            return course;
        }

        public bool IsEnrolled(int id, string userId)
        {
            return this.context.UserCourses
                .Where(c => c.CourseId == id && c.ProgrammerUserId == userId)
                .Select(c => c.IsEnrolled)
                .FirstOrDefault();
        }

        public bool IsPreviousCompleted(int id, string userId) 
        {
            id = id == 1 ? 2 : id;

            return this.context.UserCourses
                .Where(c => c.CourseId == id - 1 && c.ProgrammerUserId == userId)
                .Select(c => c.IsCompleted)
                .FirstOrDefault();
        }
    }
}

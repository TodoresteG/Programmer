namespace Programmer.Services
{
    using Programmer.App.ViewModels.Courses;
    using Programmer.App.ViewModels.Lectures;
    using Programmer.Data;
    using Programmer.Models;
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

        public CourseDetailsViewModel GetCourseDetails(int id, string userId)
        {
            var course = this.context.UserCourses
                .Where(c => c.CourseId == id && c.ProgrammerUserId == userId)
                .Select(c => new CourseDetailsViewModel
                {
                    Name = c.Course.Name,
                    Lectures = c.Course.Lectures.SelectMany(c => c.UserLectures)
                    .Where(ul => ul.ProgrammerUserId == userId)
                    .Select(ul => new LectureCourseDetailsViewModel
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

        public CourseEnrollDetailsViewModel GetCourseEnrollDetails(int id, string userId)
        {
            var course = this.context.Courses
                .Where(c => c.Id == id)
                .Select(c => new CourseEnrollDetailsViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    HardSkillReward = c.HardSkillReward * c.Lectures.Count() * 2,
                    HardSkillName = c.HardSkillName,
                    CodingSkillReward = c.SoftSkillReward * c.Lectures.Count(),
                    SoftSkillReward = c.SoftSkillReward * c.Lectures.Count(),
                    SoftSkillName = c.SoftSkillName,
                    Lectures = c.Lectures.Select(l => new LectureCourseEnrollViewModel
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
            if (id == 1)
            {
                return true;
            }

            id =- 1;

            return this.context.UserCourses
                .Where(c => c.CourseId == id && c.ProgrammerUserId == userId)
                .Select(c => c.IsCompleted)
                .FirstOrDefault();
        }
    }
}

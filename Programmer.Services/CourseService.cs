namespace Programmer.Services
{
    using Programmer.App.ViewModels.Courses;
    using Programmer.App.ViewModels.Lectures;
    using Programmer.Data;
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;
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
                .To<CourseDetailsViewModel>()
                .FirstOrDefault();

            course.Lectures = this.context.UserLectures
                .Where(ul => ul.Lecture.CourseId == id && ul.ProgrammerUserId == userId)
                .To<LectureCourseDetailsViewModel>()
                .ToList();

            return course;
        }

        public CourseEnrollDetailsViewModel GetCourseEnrollDetails(int id, string userId)
        {
            var course = this.context.Courses
                .Where(c => c.Id == id)
                .To<CourseEnrollDetailsViewModel>()
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

        public bool IsCompleted(int id, string userId) 
        {
            return this.context.UserCourses
                .Where(c => c.CourseId == id && c.ProgrammerUserId == userId)
                .Select(c => c.IsCompleted)
                .FirstOrDefault();
        }

        public bool IsPreviousCompleted(int id, string userId) 
        {
            if (id == 1)
            {
                return true;
            }

            id -= 1;

            return this.context.UserCourses
                .Where(c => c.CourseId == id && c.ProgrammerUserId == userId)
                .Select(c => c.IsCompleted)
                .FirstOrDefault();
        }
    }
}

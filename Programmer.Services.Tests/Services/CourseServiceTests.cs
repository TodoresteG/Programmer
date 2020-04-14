using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Programmer.App.ViewModels.Courses;
using Programmer.Services.Mapping;
using Programmer.Services.Tests.Fakes;
using Xunit;

namespace Programmer.Services.Tests.Services
{
    public class CourseServiceTests
    {
        [Fact]
        public void IsPreviousCompletedShouldReturnTrueWhenIdIsOne()
        {
            const string databaseName = "IsPreviousCompleted-True";

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            var fakeCourse = db.GetFakeCourse();

            db.Add(fakeUser);
            db.Add(fakeCourse);

            using (db.Data)
            {
                var courseService = new CourseService(db.Data);
                var result = courseService.IsPreviousCompleted(fakeCourse.Id, fakeUser.Id);

                Assert.True(result);
            }
        }

        [Fact]
        public void IsPreviousCompletedShouldReturnFalseWhenPreviousCourseIsNotCompleted()
        {
            const string databaseName = "IsPreviousCompleted-False-With-Two-Courses";

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            var fakeJsCourse = db.GetFakeCourse();
            fakeJsCourse.Name = "JavaScript";
            var fakeDsCourse = db.GetFakeCourse();
            fakeDsCourse.Id = 2;
            fakeDsCourse.Name = "Data Structures";
            var fakeJsUserCourse = db.GetFakeUserCourse();
            var fakeDsUserCourse = db.GetFakeUserCourse();
            fakeDsUserCourse.CourseId = 2;

            db.Add(fakeUser);
            db.Add(fakeJsCourse);
            db.Add(fakeDsCourse);
            db.Add(fakeJsUserCourse);
            db.Add(fakeDsUserCourse);

            using (db.Data)
            {
                var courseService = new CourseService(db.Data);
                var result = courseService.IsPreviousCompleted(fakeDsCourse.Id, fakeUser.Id);

                Assert.False(result);
            }
        }

        [Fact]
        public void IsPreviousCompletedShouldReturnTrueWhenPreviousCourseIsCompleted()
        {
            const string databaseName = "IsPreviousCompleted-True-With-Two-Courses";

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            var fakeJsCourse = db.GetFakeCourse();
            fakeJsCourse.Name = "JavaScript";
            var fakeDsCourse = db.GetFakeCourse();
            fakeDsCourse.Id = 2;
            fakeDsCourse.Name = "Data Structures";
            var fakeJsUserCourse = db.GetFakeUserCourse();
            fakeJsUserCourse.IsCompleted = true;
            var fakeDsUserCourse = db.GetFakeUserCourse();
            fakeDsUserCourse.CourseId = 2;

            db.Add(fakeUser);
            db.Add(fakeJsCourse);
            db.Add(fakeJsUserCourse);
            db.Add(fakeDsCourse);
            db.Add(fakeDsUserCourse);

            using (db.Data)
            {
                var courseService = new CourseService(db.Data);
                var result = courseService.IsPreviousCompleted(fakeDsCourse.Id, fakeUser.Id);

                Assert.True(result);
            }
        }

        [Fact]
        public void IsCompletedShouldReturnFalseWhenCourseIsNotCompleted()
        {
            const string databaseName = "IsCompleted-False";

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            var fakeCourse = db.GetFakeCourse();
            var fakeUserCourse = db.GetFakeUserCourse();

            db.Add(fakeUser);
            db.Add(fakeCourse);
            db.Add(fakeUserCourse);

            using (db.Data)
            {
                var courseService = new CourseService(db.Data);
                var result = courseService.IsCompleted(fakeCourse.Id, fakeUser.Id);

                Assert.False(result);
            }
        }

        [Fact]
        public void IsCompletedShouldReturnTrueWhenCourseIsCompleted()
        {
            const string databaseName = "IsCompleted-True";

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            var fakeCourse = db.GetFakeCourse();
            var fakeUserCourse = db.GetFakeUserCourse();
            fakeUserCourse.IsCompleted = true;

            db.Add(fakeUser);
            db.Add(fakeCourse);
            db.Add(fakeUserCourse);

            using (db.Data)
            {
                var courseService = new CourseService(db.Data);
                var result = courseService.IsCompleted(fakeCourse.Id, fakeUser.Id);

                Assert.True(result);
            }
        }

        [Fact]
        public void IsEnrolledShouldReturnFalseWhenCourseIsNotEnrolled()
        {
            const string databaseName = "IsEnrolled-False";

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            var fakeCourse = db.GetFakeCourse();
            var fakeUserCourse = db.GetFakeUserCourse();

            db.Add(fakeUser);
            db.Add(fakeCourse);
            db.Add(fakeUserCourse);

            using (db.Data)
            {
                var courseService = new CourseService(db.Data);
                var result = courseService.IsEnrolled(fakeCourse.Id, fakeUser.Id);

                Assert.False(result);
            }
        }

        [Fact]
        public void IsEnrolledShouldReturnTrueWhenCourseIsEnrolled()
        {
            const string databaseName = "IsEnrolled-True";

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            var fakeCourse = db.GetFakeCourse();
            var fakeUserCourse = db.GetFakeUserCourse();
            fakeUserCourse.IsEnrolled = true;

            db.Add(fakeUser);
            db.Add(fakeCourse);
            db.Add(fakeUserCourse);

            using (db.Data)
            {
                var courseService = new CourseService(db.Data);
                var result = courseService.IsEnrolled(fakeCourse.Id, fakeUser.Id);

                Assert.True(result);
            }
        }

        [Fact]
        public void GetCourseEnrollDetailsShouldReturnCourseEnrollDetailsViewModel()
        {
            const string databaseName = "GetCourseEnrollDetails-ViewModel";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            var fakeCourse = db.GetFakeCourse();
            var fakeLecture = db.GetFakeLecture();

            db.Add(fakeUser);
            db.Add(fakeCourse);
            db.Add(fakeLecture);

            using (db.Data)
            {
                var courseService = new CourseService(db.Data);
                var result = courseService.GetCourseEnrollDetails(fakeCourse.Id, fakeUser.Id);

                Assert.IsType<CourseEnrollDetailsViewModel>(result);
                Assert.Equal(1, result.Id);
                Assert.Equal("C#", result.Name);
                Assert.Equal(5, result.HardSkillReward);
                Assert.Equal("CSharp", result.HardSkillName);
                Assert.Equal(1.5, result.CodingSkillReward);
                Assert.Equal(1.5, result.SoftSkillReward);
                Assert.Equal("ProblemSolving", result.SoftSkillName);
                Assert.Equal(500m, result.Price);
                Assert.True(result.IsPreviousCompleted);
            }
        }

        [Fact]
        public void GetCourseDetailsShouldReturnCourseDetailsViewModel() 
        {
            const string databaseName = "GetCourseDetails-ViewModel";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            var fakeCourse = db.GetFakeCourse();
            var fakeExam = db.GetFakeExam();
            var fakeUserCourse = db.GetFakeUserCourse();
            var fakeLecture = db.GetFakeLecture();
            var fakeUserLecture = db.GetFakeUserLecture();

            db.Add(fakeUser);
            db.Add(fakeCourse);
            db.Add(fakeExam);
            db.Add(fakeUserCourse);
            db.Add(fakeLecture);
            db.Add(fakeUserLecture);

            using (db.Data)
            {
                var courseService = new CourseService(db.Data);
                var result = courseService.GetCourseDetails(fakeCourse.Id, fakeUser.Id);

                Assert.IsType<CourseDetailsViewModel>(result);
                Assert.Equal("C#", result.Name);
                Assert.Single(result.Lectures);
                Assert.Equal("C# - Exam", result.Exam.Name);
            }
        }

        [Fact]
        public void EnrollUserToCourseShouldReturnTrueWhenMoneyIsEnough() 
        {
            const string databaseName = "EnrollUserToCourse-True";

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            fakeUser.Money = 500;
            var fakeCourse = db.GetFakeCourse();
            var fakeLecture = db.GetFakeLecture();
            var fakeLecture1 = db.GetFakeLecture();
            fakeLecture1.Id = 2;
            var fakeLecture2 = db.GetFakeLecture();
            fakeLecture2.Id = 3;

            db.Add(fakeUser);
            db.Add(fakeCourse);
            db.Add(fakeLecture);
            db.Add(fakeLecture1);
            db.Add(fakeLecture2);

            using (db.Data)
            {
                var courseService = new CourseService(db.Data);
                var result = courseService.EnrollUserToCourse(fakeCourse.Id, fakeUser.Id);

                Assert.True(result);
                Assert.Single(db.Data.UserCourses);
                Assert.Equal(3, db.Data.UserLectures.Count());
                Assert.Equal(0, fakeUser.Money);
            }
        }

        [Fact]
        public void EnrollUserToCourseShouldReturnFalseWhenMoneyIsNotEnough() 
        {
            const string databaseName = "EnrollUserToCourse-False";

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            fakeUser.Money = 499;
            var fakeCourse = db.GetFakeCourse();

            db.Add(fakeUser);
            db.Add(fakeCourse);

            using (db.Data)
            {
                var courseService = new CourseService(db.Data);
                var result = courseService.EnrollUserToCourse(fakeCourse.Id, fakeUser.Id);

                Assert.False(result);
                Assert.Empty(db.Data.UserCourses);
                Assert.Empty(db.Data.UserLectures);
                Assert.Equal(499, fakeUser.Money);
            }
        }
    }
}

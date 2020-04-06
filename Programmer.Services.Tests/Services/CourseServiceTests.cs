using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
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
    }
}

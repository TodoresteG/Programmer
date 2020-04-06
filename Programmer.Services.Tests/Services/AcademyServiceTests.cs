namespace Programmer.Services.Tests.Services
{
    using System.Linq;
    using System.Reflection;
    using Programmer.App.ViewModels.Academy;
    using Programmer.Services.Mapping;
    using Programmer.Services.Tests.Fakes;
    using Xunit;

    public class AcademyServiceTests
    {
        [Fact]
        public void GetAllCoursesShouldReturnViewModelWithTwoCourses() 
        {
            const string databaseName = "All-Courses-AllCourses";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeCSharpCourse = db.GetFakeCourse();
            fakeCSharpCourse.Name = "C#";
            var fakeReactCourse = db.GetFakeCourse();
            fakeReactCourse.Id = 2;
            fakeReactCourse.Name = "ReactJs";
            var fakeUser = db.GetFakeUser();
            var fakeUserCSharpCourse = db.GetFakeUserCourse();
            var fakeReactUserCourse = db.GetFakeUserCourse();
            fakeReactUserCourse.CourseId = 2;

            db.Add(fakeCSharpCourse);
            db.Add(fakeReactCourse);
            db.Add(fakeUser);
            db.Add(fakeUserCSharpCourse);
            db.Add(fakeReactUserCourse);

            using (db.Data)
            {
                var academyService = new AcademyService(db.Data);
                var result = academyService.GetAllCourses(fakeUser.Id);

                Assert.IsType<AcademyAllCoursesViewModel>(result);
                Assert.Equal(2, result.AllCourses.Count());
                Assert.Empty(result.EnrolledCourses);
                Assert.Empty(result.CompletedCourses);
            }
        }

        [Fact]
        public void GetAllCoursesShouldReturnViewModelWithOneEnrolledCourse() 
        {
            const string databaseName = "All-Courses-EnrolledCourses";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeCourse = db.GetFakeCourse();
            var fakeUser = db.GetFakeUser();
            var fakeUserCourse = db.GetFakeUserCourse();
            fakeUserCourse.IsEnrolled = true;

            db.Add(fakeCourse);
            db.Add(fakeUser);
            db.Add(fakeUserCourse);

            using (db.Data)
            {
                var academyService = new AcademyService(db.Data);
                var result = academyService.GetAllCourses(fakeUser.Id);

                Assert.IsType<AcademyAllCoursesViewModel>(result);
                Assert.Single(result.AllCourses);
                Assert.Single(result.EnrolledCourses);
                Assert.Empty(result.CompletedCourses);
            }
        }

        [Fact]
        public void GetAllCoursesShouldReturnViewModelWithOneCompletedCourse() 
        {
            const string databaseName = "All-Courses-CompletedCourses";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeCourse = db.GetFakeCourse();
            var fakeUser = db.GetFakeUser();
            var fakeUserCourse = db.GetFakeUserCourse();
            fakeUserCourse.IsCompleted = true;

            db.Add(fakeCourse);
            db.Add(fakeUser);
            db.Add(fakeUserCourse);

            using (db.Data)
            {
                var academyService = new AcademyService(db.Data);
                var result = academyService.GetAllCourses(fakeUser.Id);

                Assert.IsType<AcademyAllCoursesViewModel>(result);
                Assert.Single(result.AllCourses);
                Assert.Empty(result.EnrolledCourses);
                Assert.Single(result.CompletedCourses);
            }
        }

        [Fact]
        public void GetAllCoursesShouldReturnViewModelWithTwoCoursesOneEnrolledAndOneCompleted() 
        {
            const string databaseName = "All-Courses-MixedCourses";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            var fakeDbCourse = db.GetFakeCourse();
            fakeDbCourse.Name = "C# Db";
            var fakeAspNetCoreCourse = db.GetFakeCourse();
            fakeAspNetCoreCourse.Id = 2;
            fakeAspNetCoreCourse.Name = "ASP.Net Core";
            var fakeDbUserCourse = db.GetFakeUserCourse();
            fakeDbUserCourse.IsEnrolled = true;
            var fakeAspNetCoreUserCourse = db.GetFakeUserCourse();
            fakeAspNetCoreUserCourse.CourseId = 2;
            fakeAspNetCoreUserCourse.IsCompleted = true;

            db.Add(fakeUser);
            db.Add(fakeDbCourse);
            db.Add(fakeAspNetCoreCourse);
            db.Add(fakeDbUserCourse);
            db.Add(fakeAspNetCoreUserCourse);

            using (db.Data)
            {
                var academyService = new AcademyService(db.Data);
                var result = academyService.GetAllCourses(fakeUser.Id);

                Assert.IsType<AcademyAllCoursesViewModel>(result);
                Assert.Equal(2, result.AllCourses.Count());
                Assert.Single(result.EnrolledCourses);
                Assert.Single(result.CompletedCourses);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Moq;
using Programmer.App.ViewModels.Lectures;
using Programmer.Data.Models;
using Programmer.Services.Mapping;
using Programmer.Services.Tests.Fakes;
using Xunit;

namespace Programmer.Services.Tests.Services
{
    public class LectureServiceTests
    {
        [Fact]
        public void GetLectureDetailsShoulReturnApiViewModelWithCorrectTimeNeeded()
        {
            const string databaseName = "Get-Lecture-Details";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));
            var mockService = new Mock<IUserService>();

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeLecture = db.GetFakeLecture();
            var fakeUser = db.GetFakeUser();
            var fakeCourse = db.GetFakeCourse();

            db.Add(fakeUser);
            db.Add(fakeLecture);
            db.Add(fakeCourse);

            mockService.Setup(x => x.GetTimeNeeded(fakeUser.Id)).Returns(DateTime.Now.AddSeconds(10));
            var expectedTimeNeeded = DateTime.Now.AddSeconds(10);
            using (db.Data)
            {
                var lectureService = new LectureService(db.Data, mockService.Object);
                var result = lectureService.GetLectureDetails(fakeLecture.Id, fakeUser.Id);

                Assert.IsType<LectureDetailsViewModel>(result);
                Assert.Equal(expectedTimeNeeded.ToString(), result.TimeNeeded);
            }
        }

        [Fact]
        public void WatchLectureShouldReturnTrueWhenUserHaveEnoughEnergy() 
        {
            const string databaseName = "Watch-Lecture-True";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));
            var mockService = new Mock<IUserService>();

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            fakeUser.Energy = 5;
            var fakeLecture = db.GetFakeLecture();
            var fakeCourse = db.GetFakeCourse();
            var fakeUserLecture = db.GetFakeUserLecture();

            db.Add(fakeUser);
            db.Add(fakeLecture);
            db.Add(fakeCourse);
            db.Add(fakeUserLecture);

            mockService.Setup(x => x.GetTimeNeeded(fakeUser.Id)).Returns(DateTime.Now.AddSeconds(10));
            var expectedTimeNeeded = DateTime.Now.AddSeconds(10);
            using (db.Data)
            {
                var lectureService = new LectureService(db.Data, mockService.Object);
                var result = lectureService.WatchLecture(fakeLecture.Id, fakeUser.Id);

                Assert.True(result);
            }
        }

        [Fact]
        public void WatchLectureShouldReturnFalseWhenUserDoentHaveEnoughEnergy() 
        {
            const string databaseName = "Watch-Lecture-False";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));
            var mockService = new Mock<IUserService>();

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            fakeUser.Energy = 4;
            var fakeLecture = db.GetFakeLecture();
            var fakeCourse = db.GetFakeCourse();
            var fakeUserLecture = db.GetFakeUserLecture();

            db.Add(fakeUser);
            db.Add(fakeLecture);
            db.Add(fakeCourse);
            db.Add(fakeUserLecture);

            mockService.Setup(x => x.GetTimeNeeded(fakeUser.Id)).Returns(DateTime.Now.AddSeconds(10));
            var expectedTimeNeeded = DateTime.Now.AddSeconds(10);
            using (db.Data)
            {
                var lectureService = new LectureService(db.Data, mockService.Object);
                var result = lectureService.WatchLecture(fakeLecture.Id, fakeUser.Id);

                Assert.False(result);
            }
        }
    }
}

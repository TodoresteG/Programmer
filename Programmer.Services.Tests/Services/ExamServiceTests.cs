namespace Programmer.Services.Tests.Services
{
    using System;
    using System.Reflection;
    using Moq;
    using Programmer.App.ViewModels.Exams;
    using Programmer.Services.Mapping;
    using Programmer.Services.Tests.Fakes;
    using Xunit;

    public class ExamServiceTests
    {
        [Fact]
        public void GetExamDetailsShouldReturnExamDetailsViewModel() 
        {
            const string databaseName = "Get-Exam-Details-ViewModel";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));
            var mockService = new Mock<IUserService>();

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            var fakeCourse = db.GetFakeCourse();
            var fakeExam = db.GetFakeExam();

            db.Add(fakeUser);
            db.Add(fakeCourse);
            db.Add(fakeExam);

            mockService.Setup(x => x.GetTimeNeeded(fakeUser.Id)).Returns(DateTime.Now.AddSeconds(10));
            var expectedTimeNeeded = DateTime.Now.AddSeconds(10);
            using (db.Data)
            {
                var examService = new ExamService(db.Data, mockService.Object);
                var result = examService.GetExamDetails(fakeExam.Id, fakeUser.Id);

                Assert.IsType<ExamDetailsViewModel>(result);
                Assert.Equal(expectedTimeNeeded.ToString(), result.TimeNeeded.ToString());
            }
        }

        [Fact]
        public void TakeExamShouldReturnTrueWhenPlayerHasRequiredStats() 
        {
            const string databaseName = "Take-Exam-True";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));
            var mockService = new Mock<IUserService>();

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            fakeUser.Energy = 10;
            fakeUser.CSharp = 3;
            fakeUser.Coding = 2;
            var fakeCourse = db.GetFakeCourse();
            var fakeExam = db.GetFakeExam();

            db.Add(fakeUser);
            db.Add(fakeCourse);
            db.Add(fakeExam);

            mockService.Setup(x => x.GetTimeNeeded(fakeUser.Id)).Returns(DateTime.Now.AddSeconds(10));
            var expectedTimeNeeded = DateTime.Now.AddSeconds(10);
            using (db.Data)
            {
                var examService = new ExamService(db.Data, mockService.Object);
                var result = examService.TakeExam(fakeExam.Id, fakeUser.Id);

                Assert.True(result);
                Assert.Equal(0, fakeUser.Energy);
                Assert.True(fakeUser.IsActive);
                Assert.Equal(expectedTimeNeeded.ToString(), fakeUser.TaskTimeRemaining.ToString());
                Assert.Equal("Exam", fakeUser.TypeOfTask);
            }
        }

        [Fact]
        public void TakeExamShouldReturnFalseWhenPlayerDoesNotHaveRequiredEnergy() 
        {
            const string databaseName = "Take-Exam-False-Energy";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));
            var mockService = new Mock<IUserService>();

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            fakeUser.Energy = 9;
            fakeUser.CSharp = 3;
            fakeUser.Coding = 2;
            var fakeCourse = db.GetFakeCourse();
            var fakeExam = db.GetFakeExam();

            db.Add(fakeUser);
            db.Add(fakeCourse);
            db.Add(fakeExam);

            using (db.Data)
            {
                var examService = new ExamService(db.Data, mockService.Object);
                var result = examService.TakeExam(fakeExam.Id, fakeUser.Id);

                Assert.False(result);
                Assert.Equal(9, fakeUser.Energy);
            }
        }

        [Fact]
        public void TakeExamShouldReturnFalseWhenPlayerDoesNotHaveRequiredStats() 
        {
            const string databaseName = "Take-Exam-False-Stats";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));
            var mockService = new Mock<IUserService>();

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            fakeUser.Energy = 10;
            fakeUser.CSharp = 2;
            fakeUser.Coding = 3;
            var fakeCourse = db.GetFakeCourse();
            var fakeExam = db.GetFakeExam();

            db.Add(fakeUser);
            db.Add(fakeCourse);
            db.Add(fakeExam);

            using (db.Data)
            {
                var examService = new ExamService(db.Data, mockService.Object);
                var result = examService.TakeExam(fakeExam.Id, fakeUser.Id);

                Assert.False(result);
                Assert.Equal(10, fakeUser.Energy);
            }
        }
    }
}

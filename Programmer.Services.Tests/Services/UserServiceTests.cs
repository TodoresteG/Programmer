namespace Programmer.Services.Tests.Services
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Programmer.App.ViewModels.Users;
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;
    using Programmer.Services.Tests.Fakes;
    using Xunit;

    public class UserServiceTests
    {
        private const string FakeUserId = "testId";
        private const string FakeUserUserName = "Fake Programmer User";
        private const string FakeUserEmail = "fake@programmer.user";

        [Fact]
        public void UpdateUserEnergyShouldIncrementEnergyByOne()
        {
            const string databaseName = "Energy-By-One";

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = this.GetFakeUser();
            fakeUser.Energy = 10;
            db.Add(fakeUser);

            using (db.Data)
            {
                var userService = new UserService(db.Data);
                var expctedResult = 11;
                var result = userService.UpdateUserEnergy(fakeUser.Id);
                Assert.Equal(expctedResult, result);
            }
        }

        [Fact]
        public void UpdateUserEnergyShouldReturn30WhenEnergyIs30()
        {
            const string databaseName = "Energy-30";

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = this.GetFakeUser();
            fakeUser.Energy = 30;
            db.Add(fakeUser);

            using (db.Data)
            {
                var userService = new UserService(db.Data);
                var expctedResult = 30;
                var result = userService.UpdateUserEnergy(fakeUser.Id);
                Assert.Equal(expctedResult, result);
            }
        }

        [Fact]
        public void GetTimeNeededWith10XpShouldReturn30Seconds()
        {
            const string databaseName = "Time-Needed";

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = this.GetFakeUser();
            fakeUser.Xp = 10;
            db.Add(fakeUser);

            using (db.Data)
            {
                var userService = new UserService(db.Data);
                var result = userService.GetTimeNeeded(fakeUser.Id).Second;
                var expectedResult = DateTime.Now.AddSeconds(30).Second;
                Assert.Equal(expectedResult, result);
            }
        }

        [Fact]
        public void GetPlayerInfoShouldReuturnPlayerInfoViewModel()
        {
            const string databaseName = "Player-Info";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = this.GetFakeUser();

            db.Add(fakeUser);

            using (db.Data)
            {
                var userService = new UserService(db.Data);
                var result = userService.GetPlayerInfo(fakeUser.Id);
                Assert.IsType<PlayerInfoViewModel>(result);
            }
        }

        [Fact]
        public void GetPlayerInfoShouldReturnNullWhithInvalidUserId()
        {
            const string databaseName = "Player-Info-Fail";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = this.GetFakeUser();

            db.Add(fakeUser);

            using (db.Data)
            {
                var userService = new UserService(db.Data);
                var result = userService.GetPlayerInfo("failId");
                Assert.Null(result);
            }
        }

        [Fact]
        public void UpdateUserAfterDocumentationShouldUpdateUserCorrectly()
        {
            const string databaseName = "Update-User-After-Documentation-Update-User";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = this.GetFakeUser();
            fakeUser.Xp = 1;
            fakeUser.CSharp = 1;
            var fakeDocumentation = this.GetFakeDocumentation();
            var fakeUserDocumentation = this.GetFakeUserDocumentation();

            db.Add(fakeUser);
            db.Add(fakeDocumentation);
            db.Add(fakeUserDocumentation);

            using (db.Data)
            {
                var userService = new UserService(db.Data);
                var result = userService.UpdateUserAfterDocumentation(fakeUser.Id);

                Assert.Equal(11, fakeUser.Xp);
                Assert.Equal(6, fakeUser.CSharp);
                Assert.Null(fakeUser.TypeOfTask);
                Assert.Null(fakeUser.TaskTimeRemaining);
                Assert.False(fakeUser.IsActive);
            }
        }

        [Fact]
        public void UpdateUserAfterDocumentationShouldRemoveUserDocumentationRecord()
        {
            const string databaseName = "Update-User-After-Documentation-Remove-UserDocumentation-Record";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = this.GetFakeUser();
            fakeUser.Xp = 1;
            fakeUser.CSharp = 1;
            var fakeDocumentation = this.GetFakeDocumentation();
            var fakeUserDocumentation = this.GetFakeUserDocumentation();

            db.Add(fakeUser);
            db.Add(fakeDocumentation);
            db.Add(fakeUserDocumentation);

            using (db.Data)
            {
                var userService = new UserService(db.Data);
                var result = userService.UpdateUserAfterDocumentation(fakeUser.Id);

                Assert.Equal(0, db.Data.UserDocumentations.Count());
            }
        }

        [Fact]
        public void UpdateUserAfterDocumentationShouldReturnApiViewModel()
        {
            const string databaseName = "Update-User-After-Documentation-Api-View-Model";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = this.GetFakeUser();
            fakeUser.Xp = 1;
            fakeUser.CSharp = 1;
            var fakeDocumentation = this.GetFakeDocumentation();
            var fakeUserDocumentation = this.GetFakeUserDocumentation();

            db.Add(fakeUser);
            db.Add(fakeDocumentation);
            db.Add(fakeUserDocumentation);

            using (db.Data)
            {
                var userService = new UserService(db.Data);
                var result = userService.UpdateUserAfterDocumentation(fakeUser.Id);

                Assert.IsType<UpdateUserAfterActivityApiModel>(result);
                Assert.Equal(6, result.HardSkill);
                Assert.Equal("csharp", result.HardSkillName);
                Assert.Equal(11, result.Xp);
            }
        }

        [Fact]
        public void UpdateUserAfterExamShouldUpdateUserCorrectly()
        {
            const string databaseName = "Update-User-After-Exam-Update-User";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = this.GetFakeUser();
            var fakeUserCourse = this.GetFakeUserCourse();

            db.Add(fakeUser);
            db.Add(fakeUserCourse);

            using (db.Data)
            {
                var userService = new UserService(db.Data);
                var result = userService.UpdateUserAfterExam(fakeUser.Id);

                Assert.Null(fakeUser.TypeOfTask);
                Assert.Null(fakeUser.TaskTimeRemaining);
                Assert.False(fakeUser.IsActive);
            }
        }

        [Fact]
        public void UpdateUserAfterExamShouldUpdateUserCourseCorrectly()
        {
            const string databaseName = "Update-User-After-Exam-Update-UserCourse";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = this.GetFakeUser();
            var fakeUserCourse = this.GetFakeUserCourse();

            db.Add(fakeUser);
            db.Add(fakeUserCourse);

            using (db.Data)
            {
                var userService = new UserService(db.Data);
                var result = userService.UpdateUserAfterExam(fakeUser.Id);

                Assert.True(fakeUserCourse.IsCompleted);
                Assert.False(fakeUserCourse.IsEnrolled);
            }
        }

        [Fact]
        public void UpdateUserAfterExamShouldReturnApiViewModel()
        {
            const string databaseName = "Update-User-After-Exam-Api-View-Model";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = this.GetFakeUser();
            var fakeUserCourse = this.GetFakeUserCourse();

            db.Add(fakeUser);
            db.Add(fakeUserCourse);

            using (db.Data)
            {
                var userService = new UserService(db.Data);
                var result = userService.UpdateUserAfterExam(fakeUser.Id);

                Assert.IsType<UpdateUserAfterActivityApiModel>(result);
            }
        }

        [Fact]
        public void UpdateUserAfterLectureShouldUpdateUserCorrectly()
        {
            const string databaseName = "Update-User-After-Lecture-Update-User";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = this.GetFakeUser();
            fakeUser.Xp = 1;
            fakeUser.CSharp = 1;
            fakeUser.ProblemSolving = 1;
            var fakeCourse = this.GetFakeCourse();
            var fakeUserCourse = this.GetFakeUserCourse();
            var fakeLecture = this.GetFakeLecture();
            var fakeUserLecture = this.GetFakeUserLecture();

            db.Add(fakeUser);
            db.Add(fakeCourse);
            db.Add(fakeUserCourse);
            db.Add(fakeLecture);
            db.Add(fakeUserLecture);

            using (db.Data)
            {
                var userService = new UserService(db.Data);
                var result = userService.UpdateUserAfterLecture(fakeUser.Id);

                Assert.Equal(11, fakeUser.Xp);
                Assert.Equal(6, fakeUser.CSharp);
                Assert.Equal(4, fakeUser.ProblemSolving);
                Assert.Null(fakeUser.TaskTimeRemaining);
                Assert.Null(fakeUser.TypeOfTask);
                Assert.False(fakeUser.IsActive);
            }
        }

        [Fact]
        public void UpdateUserAfterLectureShouldUpdateUserLectureCorrectly()
        {
            const string databaseName = "Update-User-After-Lecture-Update-UserLecture";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = this.GetFakeUser();
            fakeUser.Xp = 1;
            fakeUser.CSharp = 1;
            fakeUser.ProblemSolving = 1;
            var fakeCourse = this.GetFakeCourse();
            var fakeUserCourse = this.GetFakeUserCourse();
            var fakeLecture = this.GetFakeLecture();
            var fakeUserLecture = this.GetFakeUserLecture();

            db.Add(fakeUser);
            db.Add(fakeCourse);
            db.Add(fakeUserCourse);
            db.Add(fakeLecture);
            db.Add(fakeUserLecture);

            using (db.Data)
            {
                var userService = new UserService(db.Data);
                var result = userService.UpdateUserAfterLecture(fakeUser.Id);

                Assert.True(fakeUserLecture.IsCompleted);
                Assert.False(fakeUserLecture.IsActive);
            }
        }

        [Fact]
        public void UpdateUserAfterLectureShouldReturnApiViewModel()
        {
            const string databaseName = "Update-User-After-Lecture-Update-UserLecture";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = this.GetFakeUser();
            fakeUser.Xp = 1;
            fakeUser.CSharp = 1;
            fakeUser.ProblemSolving = 1;
            var fakeCourse = this.GetFakeCourse();
            var fakeUserCourse = this.GetFakeUserCourse();
            var fakeLecture = this.GetFakeLecture();
            var fakeUserLecture = this.GetFakeUserLecture();

            db.Add(fakeUser);
            db.Add(fakeCourse);
            db.Add(fakeUserCourse);
            db.Add(fakeLecture);
            db.Add(fakeUserLecture);

            using (db.Data)
            {
                var userService = new UserService(db.Data);
                var result = userService.UpdateUserAfterLecture(fakeUser.Id);

                Assert.IsType<UpdateUserAfterActivityApiModel>(result);
                Assert.Equal("problemsolving", result.SoftSkillName);
                Assert.Equal(4, result.SoftSkill);
                Assert.Equal("csharp", result.HardSkillName);
                Assert.Equal(6, result.HardSkill);
                Assert.Equal(11, result.Xp);
                Assert.Equal(22, result.XpForNextLevel);
            }
        }

        // TODO: Maybe put these in another class
        private ProgrammerUser GetFakeUser()
        {
            return new ProgrammerUser
            {
                Id = FakeUserId,
                UserName = FakeUserUserName,
                Email = FakeUserEmail,
            };
        }

        private Documentation GetFakeDocumentation()
        {
            return new Documentation
            {
                Id = 1,
                Name = "C# Tips And Tricks",
                XpReward = 10,
                RequiredEnergy = 7,
                HardSkillName = "CSharp",
                HardSkillReward = 5,
            };
        }

        private UserDocumentation GetFakeUserDocumentation()
        {
            return new UserDocumentation
            {
                DocumentationId = 1,
                ProgrammerId = FakeUserId,
            };
        }

        private Course GetFakeCourse()
        {
            return new Course
            {
                Id = 1,
                XpReward = 10,
                HardSkillName = "CSharp",
                HardSkillReward = 5,
                RequiredEnergy = 5,
                SoftSkillName = "ProblemSolving",
                SoftSkillReward = 3,
            };
        }

        private UserCourse GetFakeUserCourse()
        {
            return new UserCourse
            {
                CourseId = 1,
                ProgrammerUserId = FakeUserId,
            };
        }

        private Lecture GetFakeLecture()
        {
            return new Lecture
            {
                Id = 1,
                CourseId = 1,
                Name = "Test Lecture"
            };
        }

        private UserLecture GetFakeUserLecture()
        {
            return new UserLecture
            {
                LectureId = 1,
                ProgrammerUserId = FakeUserId,
                IsActive = true,
            };
        }
    }
}

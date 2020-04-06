namespace Programmer.Services.Tests.Fakes
{
    using Microsoft.EntityFrameworkCore;
    using Programmer.Data;
    using Programmer.Data.Models;

    public class FakeProgrammerDbContext
    {
        private const string FakeUserId = "testId";
        private const string FakeUserUserName = "Fake Programmer User";
        private const string FakeUserEmail = "fake@programmer.user";

        public FakeProgrammerDbContext(string name)
        {
            var options = new DbContextOptionsBuilder<ProgrammerDbContext>()
               .UseInMemoryDatabase(name)
               .Options;

            this.Data = new ProgrammerDbContext(options);
        }

        public ProgrammerDbContext Data { get; }

        public void Add(params object[] data) 
        {
            this.Data.AddRange(data);
            this.Data.SaveChanges();
        }

        public ProgrammerUser GetFakeUser()
        {
            return new ProgrammerUser
            {
                Id = FakeUserId,
                UserName = FakeUserUserName,
                Email = FakeUserEmail,
            };
        }

        public Documentation GetFakeDocumentation()
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

        public UserDocumentation GetFakeUserDocumentation()
        {
            return new UserDocumentation
            {
                DocumentationId = 1,
                ProgrammerId = FakeUserId,
            };
        }

        public Course GetFakeCourse()
        {
            return new Course
            {
                Id = 1,
                Name = "C#",
                XpReward = 10,
                HardSkillName = "CSharp",
                HardSkillReward = 5,
                RequiredEnergy = 5,
                SoftSkillName = "ProblemSolving",
                SoftSkillReward = 3,
                Price = 500m,
            };
        }

        public UserCourse GetFakeUserCourse()
        {
            return new UserCourse
            {
                CourseId = 1,
                ProgrammerUserId = FakeUserId,
            };
        }

        public Lecture GetFakeLecture()
        {
            return new Lecture
            {
                Id = 1,
                CourseId = 1,
                Name = "Test Lecture"
            };
        }

        public UserLecture GetFakeUserLecture()
        {
            return new UserLecture
            {
                LectureId = 1,
                ProgrammerUserId = FakeUserId,
                IsActive = true,
            };
        }

        public Exam GetFakeExam() 
        {
            return new Exam
            {
                Id = 1,
                CourseId = 1,
            };
        }
    }
}

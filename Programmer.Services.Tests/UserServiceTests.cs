namespace Programmer.Services.Tests
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Programmer.Data;
    using Programmer.Data.Models;
    using Programmer.Services.Tests.Fakes;
    using Xunit;

    public class UserServiceTests
    {
        [Fact]
        public void UpdateUserEnergyShouldIncrementEnergyByOne()
        {
            var fakeUser = this.GetFakeUser();
            var options = new DbContextOptionsBuilder<ProgrammerDbContext>()
                .UseInMemoryDatabase("In-Memory Database")
                .Options;

            using (var context = new ProgrammerDbContext(options))
            {
                context.Users.Add(new ProgrammerUser
                {
                    Id = "testId",
                    UserName = "Fake Programmer User",
                    Email = "fake@programmer.user",
                    AbstractThinking = 1,
                    Coding = 2,
                    Creativity = 0,
                    Curiosity = 5,
                    ProblemSolving = 3,
                    Teamwork = 0,
                    Xp = 1,
                    Bitcoins = 100,
                    Energy = 10,
                    IsActive = false,
                    Level = 1,
                    Money = 1000,
                    CreatedOn = new DateTime(1999, 08, 16),
                });

                context.SaveChanges();

            }

            using (var context = new ProgrammerDbContext(options))
            {
                var userService = new UserService(context);
                var expctedResult = 11;
                var result = userService.UpdateUserEnergy(fakeUser.Id);
                Assert.Equal(expctedResult, result);
            }
        }

        private FakeProgrammerUser GetFakeUser()
        {
            return new FakeProgrammerUser
            {
                Id = "testId",
                UserName = "Fake Programmer User",
                Email = "fake@programmer.user",
                AbstractThinking = 1,
                Coding = 2,
                Creativity = 0,
                Curiosity = 5,
                ProblemSolving = 3,
                Teamwork = 0,
                Xp = 1,
                Bitcoins = 100,
                Energy = 10,
                IsActive = false,
                Level = 1,
                Money = 1000,
                CreatedOn = new DateTime(1999, 08, 16),
            };
        }
    }
}

namespace Programmer.Services.Tests.Services
{
    using System;
    using Programmer.App.ViewModels.Users;
    using Programmer.Data.Models;
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
                var result = userService.UpdateUserEnergy(FakeUserId);
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
                var result = userService.UpdateUserEnergy(FakeUserId);
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
                var result = userService.GetTimeNeeded(FakeUserId).Second;
                var expectedResult = DateTime.Now.AddSeconds(30).Second;
                Assert.Equal(expectedResult, result);
            }
        }

        //[Fact]
        //public void GetPlayerInfoShouldReuturnPlayerInfoViewModel()
        //{
        //    const string databaseName = "Player-Info";

        //    var db = new FakeProgrammerDbContext(databaseName);
        //    var fakeUser = this.GetFakeUser();

        //    db.Add(fakeUser);

        //    using (db.Data)
        //    {
        //        var userService = new UserService(db.Data);
        //        var result = userService.GetPlayerInfo(FakeUserId);
        //        Assert.IsType<PlayerInfoViewModel>(result);
        //    }
        //}

        private ProgrammerUser GetFakeUser()
        {
            return new ProgrammerUser
            {
                Id = FakeUserId,
                UserName = FakeUserUserName,
                Email = FakeUserEmail,
                Level = 1,
                Xp = 1,
                Money = 1,
                Bitcoins = 1,
                Energy = 1,
                IsActive = false,
            };
        }
    }
}

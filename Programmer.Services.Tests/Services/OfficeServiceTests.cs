namespace Programmer.Services.Tests.Services
{
    using System.Reflection;
    using Programmer.App.ViewModels.Office;
    using Programmer.Services.Mapping;
    using Programmer.Services.Tests.Fakes;
    using Xunit;

    public class OfficeServiceTests
    {
        [Fact]
        public void GetUserForHomeShouldReturnViewModelWithDefaultUserStats() 
        {
            const string databaseName = "Get-User-For-Home-ViewModel";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();

            db.Add(fakeUser);

            using (db.Data)
            {
                var officeService = new OfficeService(db.Data);
                var result = officeService.GetUserForHome(fakeUser.Id);

                Assert.IsType<OfficeViewModel>(result);
                Assert.Equal(6, result.UserStats.Count);
            }
        }

        [Fact]
        public void GetUserForHomeShouldReturnViewModelWithAdditionalUserStats() 
        {
            const string databaseName = "Get-User-For-Home-Additional-Stats";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            fakeUser.Testing = 2;
            fakeUser.VanillaJavaScript = 3;
            fakeUser.React = 4;

            db.Add(fakeUser);

            using (db.Data)
            {
                var officeService = new OfficeService(db.Data);
                var result = officeService.GetUserForHome(fakeUser.Id);

                Assert.IsType<OfficeViewModel>(result);
                Assert.Equal(9, result.UserStats.Count);
            }
        }
    }
}

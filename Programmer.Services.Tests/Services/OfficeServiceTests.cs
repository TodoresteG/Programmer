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
        public void GetUserForHomeShouldReturnViewModelWithUserStats() 
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
    }
}

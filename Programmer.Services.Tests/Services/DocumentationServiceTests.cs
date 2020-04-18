namespace Programmer.Services.Tests.Services
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Moq;
    using Programmer.App.ViewModels.Documentations;
    using Programmer.Services.Mapping;
    using Programmer.Services.Tests.Fakes;
    using Xunit;

    public class DocumentationServiceTests
    {
        [Fact]
        public void GetDocumentationsForIndexShouldReturnViewModel() 
        {
            const string databaseName = "Get-Documentations-For-Index-ViewModel";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));
            var mockService = new Mock<IUserService>();

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeuser = db.GetFakeUser();
            var fakeCSharp = db.GetFakeDocumentation();
            var fakeJs = db.GetFakeDocumentation();
            fakeJs.Id = 2;
            fakeJs.Name = "Js";
            fakeJs.HardSkillName = "VanillaJavaScript";

            db.Add(fakeuser);
            db.Add(fakeCSharp);
            db.Add(fakeJs);

            using (db.Data)
            {
                var documentationService = new DocumentationService(db.Data, mockService.Object);
                var result = documentationService.GetDocumentationsForIndex();

                Assert.IsType<AllDocumentationsIndexViewModel>(result);
                Assert.Equal(2, result.Documentations.Count());
            }
        }

        [Fact]
        public void ReadDocumentationShouldReturnFalseWhenRequiredEnergyIsNotEnough() 
        {
            const string databaseName = "Read-Documentation-False";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));
            var mockService = new Mock<IUserService>();

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            fakeUser.Energy = 6;
            var fakeDocumentation = db.GetFakeDocumentation();

            db.Add(fakeUser);
            db.Add(fakeDocumentation);

            using (db.Data)
            {
                var documentationService = new DocumentationService(db.Data, mockService.Object);
                var result = documentationService.ReadDocumentation(fakeDocumentation.Id, fakeUser.Id);

                Assert.False(result);
                Assert.False(fakeUser.IsActive);
                Assert.Null(fakeUser.TypeOfTask);
                Assert.Null(fakeUser.TaskTimeRemaining);
                Assert.Equal(6, fakeUser.Energy);
                Assert.Empty(db.Data.UserDocumentations);
            }
        }

        [Fact]
        public void ReadDocumentationShouldReturnTrueAndUpdatePlayer() 
        {
            const string databaseName = "Read-Documentation-True";
            AutoMapperConfig.RegisterMappings(Assembly.Load("Programmer.App.ViewModels"));
            var mockService = new Mock<IUserService>();

            var db = new FakeProgrammerDbContext(databaseName);
            var fakeUser = db.GetFakeUser();
            fakeUser.Energy = 7;
            var fakeDocumentation = db.GetFakeDocumentation();

            db.Add(fakeUser);
            db.Add(fakeDocumentation);

            mockService.Setup(x => x.GetTimeNeeded(fakeUser.Id)).Returns(DateTime.Now.AddSeconds(10));
            var expectedTime = DateTime.Now.AddSeconds(10).ToString();
            using (db.Data)
            {
                var documentationService = new DocumentationService(db.Data, mockService.Object);
                var result = documentationService.ReadDocumentation(fakeDocumentation.Id, fakeUser.Id);

                Assert.True(result);
                Assert.True(fakeUser.IsActive);
                Assert.Equal(0, fakeUser.Energy);
                Assert.Equal(expectedTime, fakeUser.TaskTimeRemaining.ToString());
                Assert.Equal("Documentation", fakeUser.TypeOfTask);
                Assert.Single(db.Data.UserDocumentations);
            }
        }
    }
}

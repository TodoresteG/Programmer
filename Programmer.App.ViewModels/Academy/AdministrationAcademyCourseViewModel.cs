namespace Programmer.App.ViewModels.Academy
{
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;

    public class AdministrationAcademyCourseViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

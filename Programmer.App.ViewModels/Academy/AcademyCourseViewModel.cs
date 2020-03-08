namespace Programmer.App.ViewModels.Academy
{
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;

    public class AcademyCourseViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsEnrolled { get; set; }
    }
}

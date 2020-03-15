namespace Programmer.App.ViewModels.Academy
{
    using AutoMapper;
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;
    using System.Linq;

    public class AcademyCourseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsEnrolled { get; set; }

        public bool IsCompleted { get; set; }
    }
}

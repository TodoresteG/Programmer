namespace Programmer.App.ViewModels.Academy
{
    using AutoMapper;
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;

    public class AcademyEnrolledCourseViewModel : IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<UserCourse, AcademyEnrolledCourseViewModel>()
                .ForMember(m => m.Id, opt => opt.MapFrom(x => x.CourseId))
                .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Course.Name));
        }
    }
}

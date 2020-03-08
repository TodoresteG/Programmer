namespace Programmer.App.ViewModels.Academy
{
    using AutoMapper;
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;

    public class AcademyCompletedCourseViewModel : IHaveCustomMappings
    {
        public string Name { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<UserCourse, AcademyCompletedCourseViewModel>()
                .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Course.Name));
        }
    }
}

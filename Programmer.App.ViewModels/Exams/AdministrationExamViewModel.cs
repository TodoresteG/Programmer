namespace Programmer.App.ViewModels.Exams
{
    using AutoMapper;
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;

    public class AdministrationExamViewModel : IMapFrom<Exam>, IHaveCustomMappings
    {
        public  int Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Exam, AdministrationExamViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Course.Name));
        }
    }
}

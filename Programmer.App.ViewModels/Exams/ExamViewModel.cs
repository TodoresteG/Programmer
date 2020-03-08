namespace Programmer.App.ViewModels.Exams
{
    using AutoMapper;
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;

    public class ExamViewModel : IMapFrom<Exam>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Exam, ExamViewModel>()
                .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Course.Name + " - Exam"));
        }
    }
}

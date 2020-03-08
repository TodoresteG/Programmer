namespace Programmer.App.ViewModels.Exams
{
    using AutoMapper;
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;

    public class ExamDetailsViewModel : IMapFrom<Exam>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int RequiredEnergy { get; set; }

        public double RequiredHardSkill { get; set; }

        public string RequiredHardSkillName { get; set; }

        public double RequiredCodingSkill { get; set; }

        public string TimeNeeded { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Exam, ExamDetailsViewModel>()
                .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Course.Name + " - Exam"));
        }
    }
}

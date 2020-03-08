namespace Programmer.App.ViewModels.Lectures
{
    using AutoMapper;
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;

    public class LectureDetailsViewModel : IMapFrom<Lecture>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int RequiredEnergy { get; set; }

        public string TimeNeeded { get; set; }

        public double HardSkillReward { get; set; }

        public string HardSkillName { get; set; }

        public double SoftSkillReward { get; set; }

        public string SoftSkillName { get; set; }

        public int XpReward { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Lecture, LectureDetailsViewModel>()
                .ForMember(m => m.RequiredEnergy, opt => opt.MapFrom(x => x.Course.RequiredEnergy))
                .ForMember(m => m.HardSkillReward, opt => opt.MapFrom(x => x.Course.HardSkillReward))
                .ForMember(m => m.HardSkillName, opt => opt.MapFrom(x => x.Course.HardSkillName))
                .ForMember(m => m.SoftSkillReward, opt => opt.MapFrom(x => x.Course.SoftSkillReward))
                .ForMember(m => m.SoftSkillName, opt => opt.MapFrom(x => x.Course.SoftSkillName))
                .ForMember(m => m.XpReward, opt => opt.MapFrom(x => x.Course.XpReward));
        }
    }
}

namespace Programmer.App.ViewModels.Courses
{
    using AutoMapper;
    using Programmer.App.ViewModels.Lectures;
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;
    using System.Collections.Generic;

    public class CourseEnrollDetailsViewModel : IMapFrom<Course>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double HardSkillReward { get; set; }

        public string HardSkillName { get; set; }

        public double CodingSkillReward { get; set; }

        public double SoftSkillReward { get; set; }

        public string SoftSkillName { get; set; }

        public bool IsPreviousCompleted { get; set; }

        public decimal Price { get; set; }

        public IList<LectureCourseEnrollViewModel> Lectures { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Course, CourseEnrollDetailsViewModel>()
                .ForMember(m => m.HardSkillReward, opt => opt.MapFrom(x => x.HardSkillReward * x.Lectures.Count))
                .ForMember(m => m.SoftSkillReward, opt => opt.MapFrom(x => (x.SoftSkillReward * x.Lectures.Count) / 2))
                .ForMember(m => m.CodingSkillReward, opt => opt.MapFrom(x => (x.SoftSkillReward * x.Lectures.Count) / 2));
        }
    }
}

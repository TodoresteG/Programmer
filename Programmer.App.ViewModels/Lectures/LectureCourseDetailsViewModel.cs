namespace Programmer.App.ViewModels.Lectures
{
    using AutoMapper;
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;

    public class LectureCourseDetailsViewModel : IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsCompleted { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<UserLecture, LectureCourseDetailsViewModel>()
                .ForMember(m => m.Id, opt => opt.MapFrom(x => x.LectureId))
                .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Lecture.Name))
                .ForMember(m => m.IsCompleted, opt => opt.MapFrom(x => x.IsCompleted));
        }
    }
}

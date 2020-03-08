namespace Programmer.App.ViewModels.Courses
{
    using AutoMapper;
    using Programmer.App.ViewModels.Exams;
    using Programmer.App.ViewModels.Lectures;
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;
    using System.Collections.Generic;

    public class CourseDetailsViewModel : IHaveCustomMappings
    {
        public string Name { get; set; }

        public IList<LectureCourseDetailsViewModel> Lectures { get; set; }

        public ExamViewModel Exam { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<UserCourse, CourseDetailsViewModel>()
                .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Course.Name))
                .ForMember(m => m.Exam, opt => opt.MapFrom(x => x.Course.Exam));
        }
    }
}

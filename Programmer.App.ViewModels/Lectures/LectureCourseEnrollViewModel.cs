namespace Programmer.App.ViewModels.Lectures
{
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;

    public class LectureCourseEnrollViewModel : IMapFrom<Lecture>
    {
        public string Name { get; set; }
    }
}

namespace Programmer.App.ViewModels.Lectures
{
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;

    public class AdministrationLectureViewModel : IMapFrom<Lecture>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

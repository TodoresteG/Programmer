namespace Programmer.Services
{
    using Programmer.App.ViewModels.Lectures;

    public interface ILectureService
    {
        LectureDetailsViewModel GetLectureDetails(int id, string userId);

        void WatchLecture(int id, string userId);
    }
}

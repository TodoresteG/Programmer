namespace Programmer.Services
{
    using Dtos.Lectures;
    using System.Threading.Tasks;

    public interface ILectureService
    {
        LectureDetailsDto GetLectureDetails(int id);

        Task WatchLecture(int id, string userId);
    }
}

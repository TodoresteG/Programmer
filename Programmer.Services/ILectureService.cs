namespace Programmer.Services
{
    using Dtos.Lectures;
    using System.Threading.Tasks;

    public interface ILectureService
    {
        LectureDetailsDto GetLectureDetails(int id, string userId);

        void WatchLecture(int id, string userId);

        void UpdateUser(string userId, int lectureId);
    }
}

namespace Programmer.Services
{
    using Dtos.Lectures;
    using System;
    using System.Threading.Tasks;

    public interface ILectureService
    {
        LectureDetailsDto GetLectureDetails(int id, string userId);

        void WatchLecture(int id, string userId);

        void UpdateUser(string userId);

        public DateTime GetTimeNeeded(int id, string userId);
    }
}

namespace Programmer.Services
{
    using System.Linq;
    using Programmer.Data;
    using Programmer.Services.Dtos.Lectures;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;
    using Programmer.Models;

    public class LectureService : ILectureService
    {
        private readonly ProgrammerDbContext context;

        public LectureService(ProgrammerDbContext context)
        {
            this.context = context;
        }

        public LectureDetailsDto GetLectureDetails(int id, string userId)
        {
            var lecture = this.context.Lectures
                .Where(l => l.Id == id)
                .Include(l => l.Course)
                .Select(l => new LectureDetailsDto
                {
                    Id = l.Id,
                    Name = l.Name,
                    HardSkillReward = l.Course.HardSkillReward,
                    SoftSkillReward = l.Course.SoftSkillReward,
                    RequiredEnergy = l.Course.RequiredEnergy,
                    TimeNeeded = this.GetTimeNeeded(id, userId).ToString(),
                    XpReward = l.Course.XpReward,
                })
                .FirstOrDefault();

            return lecture;
        }

        public void WatchLecture(int id, string userId)
        {
            // TODO: bad queries - fix them
            var user = this.context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefault();

            var userLecture = this.context.UserLectures
                .Include(ul => ul.Lecture.Course)
                .FirstOrDefault(ul => ul.LectureId == id && ul.ProgrammerUserId == userId);

            user.Energy -= userLecture.Lecture.Course.RequiredEnergy;
            user.IsActive = true;
            user.TaskTimeRemaining = this.GetTimeNeeded(id, userId);

            userLecture.IsActive = true;

            this.context.Users.Update(user);
            this.context.UserLectures.Update(userLecture);
            this.context.SaveChanges();
        }

        private DateTime GetTimeNeeded(int id, string userId)
        {
            var userXp = this.context.Lectures
                .Where(l => l.Id == id)
                .SelectMany(l => l.Course.Users)
                .Where(u => u.User.Id == userId)
                .Select(u => u.User.Xp)
                .FirstOrDefault();

            var userLevel = this.context.Lectures
                .Where(l => l.Id == id)
                .SelectMany(l => l.Course.Users)
                .Select(u => u.User.Level)
                .FirstOrDefault();

            var baseTime = this.context.Lectures
                .Where(l => l.Id == id)
                .Select(l => l.Course.BaseTimeNeeded.TotalSeconds)
                .FirstOrDefault();

            var time = TimeSpan.FromSeconds(Math.Round(userXp / userLevel * baseTime)).TotalSeconds;
            return DateTime.Now.AddSeconds(time);
        }
    }
}

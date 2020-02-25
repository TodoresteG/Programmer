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
                    XpReward = l.XpReward,
                })
                .FirstOrDefault();

            return lecture;
        }

        public void WatchLecture(int id, string userId)
        {
            // TODO: bad queries - fix them
            var user = this.context.Users.Find(userId);
            var lecture = this.context.Lectures.Include(l => l.Course).FirstOrDefault(l => l.Id == id);

            user.Energy -= lecture.Course.RequiredEnergy;
            user.IsActive = true;
            user.TaskTimeRemaining = this.GetTimeNeeded(id, userId);

            this.context.Update(user);
            this.context.SaveChanges();
        }

        public void UpdateUser(string userId, int lectureId)
        {
            var user = this.context.Users.Find(userId);
            var lecture = this.context.Lectures.Include(l => l.Course).FirstOrDefault(l => l.Id == lectureId);

            if (lecture.Course.Name.Contains("C#"))
            {
                user.CSharp += lecture.Course.HardSkillReward;
                user.ProblemSolving += lecture.Course.SoftSkillReward;
            }
            else if (lecture.Course.Name == "Data Structures")
            {
                user.DataStructures += lecture.Course.HardSkillReward;
                user.AbstractThinking += lecture.Course.SoftSkillReward;
            }
            else if (lecture.Course.Name == "Algorithms")
            {
                user.Algorithms += lecture.Course.HardSkillReward;
                user.AbstractThinking += lecture.Course.SoftSkillReward;
            }
            else if (lecture.Course.Name == "Unit Testing")
            {
                user.Testing += lecture.Course.HardSkillReward;
                user.AbstractThinking += lecture.Course.SoftSkillReward;
            }

            user.Xp += lecture.XpReward;
            user.TaskTimeRemaining = null;
            user.IsActive = false;

            lecture.IsCompleted = true;

            this.context.Users.Update(user);
            this.context.Lectures.Update(lecture);

            this.context.SaveChanges();
        }

        private TimeSpan GetTimeNeeded(int id, string userId)
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

            return TimeSpan.FromSeconds(Math.Round(userXp / userLevel * baseTime));
        }
    }
}

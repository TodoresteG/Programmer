namespace Programmer.Services
{
    using System.Linq;
    using Programmer.Data;
    using Programmer.Services.Dtos.Lectures;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class LectureService : ILectureService
    {
        private readonly ProgrammerDbContext context;

        public LectureService(ProgrammerDbContext context)
        {
            this.context = context;
        }

        public LectureDetailsDto GetLectureDetails(int id)
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
                    TimeNeeded = this.GetTimeNeeded(id).ToString(),
                    XpReward = l.XpReward,
                })
                .FirstOrDefault();

            return lecture;
        }

        public async Task WatchLecture(int id, string userId)
        {
            // TODO: bad queries - fix them
            var user = this.context.Users.Find(userId);
            var lecture = this.context.Lectures.Include(l => l.Course).FirstOrDefault(l => l.Id == id);

            user.Energy -= lecture.Course.RequiredEnergy;
            user.IsActive = true;
            user.TaskTimeRemaining = this.GetTimeNeeded(id);

            Task.Run(async () =>
            {
                await Task.Delay((int)user.TaskTimeRemaining?.TotalMilliseconds);

                user.CSharp += lecture.Course.HardSkillReward;
                user.ProblemSolving += lecture.Course.SoftSkillReward;
                user.Xp += lecture.XpReward;

                lecture.IsCompleted = true;

                this.context.Users.Update(user);
                this.context.Lectures.Update(lecture);
                this.context.SaveChanges();
            });

            //player.Energy -= lecture.Course.RequiredEnergy;
            //player.IsActive = true;
            //player.TaskTimeRemaining = lecture.TimeNeeded;

            //var test = DateTime.UtcNow.AddSeconds((double)player.TaskTimeRemaining?.TotalSeconds);

            //await Task.Delay((int)player.TaskTimeRemaining?.TotalMilliseconds);

            //player.HardSkills.CSharp += lecture.Course.HardSkillReward;
            //player.SoftSkills.ProblemSolving += lecture.Course.SoftSkillReward;
            //player.Xp += lecture.XpReward;

            //context.SaveChanges();
        }

        private TimeSpan GetTimeNeeded(int id) 
        {
            var userXp = this.context.Lectures
                .Where(l => l.Id == id)
                .SelectMany(l => l.Course.Users)
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

namespace Programmer.Services
{
    using System.Linq;
    using Programmer.Data;
    using Programmer.Services.Dtos.Lectures;
    using Microsoft.EntityFrameworkCore;

    public class LectureService : ILectureService
    {
        private readonly ProgrammerDbContext context;
        private readonly IUserService userService;

        public LectureService(ProgrammerDbContext context, IUserService userService)
        {
            this.context = context;
            this.userService = userService;
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
                    HardSkillName = l.Course.HardSkillName,
                    SoftSkillReward = l.Course.SoftSkillReward,
                    SoftSkillName = l.Course.SoftSkillName,
                    RequiredEnergy = l.Course.RequiredEnergy,
                    TimeNeeded = this.userService.GetTimeNeeded(userId).ToString(),
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
            user.TaskTimeRemaining = this.userService.GetTimeNeeded(userId);

            userLecture.IsActive = true;

            this.context.Users.Update(user);
            this.context.UserLectures.Update(userLecture);
            this.context.SaveChanges();
        }
    }
}

namespace Programmer.Services
{
    using Microsoft.EntityFrameworkCore;
    using Programmer.Data;
    using Programmer.Models;
    using Programmer.Services.Dtos.Users;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly ProgrammerDbContext context;

        public UserService(ProgrammerDbContext context)
        {
            this.context = context;
        }

        public UserInfoDto GetPlayerInfo(string userId)
        {
            var user = this.context.Users
                .Where(u => u.Id == userId)
                .Select(u => new UserInfoDto
                {
                    Bitcoins = u.Bitcoins,
                    Energy = u.Energy,
                    IsActive = u.IsActive,
                    Level = u.Level,
                    Money = u.Money,
                    TimeRemaining = u.TaskTimeRemaining,
                    Xp = u.Xp,
                    XpForNextLevel = u.XpForNextLevel,
                })
                .FirstOrDefault();

            return user;
        }

        public async Task<int> UpdateUserEnergy(string userId)
        {
            var user = this.context.Users
                .FirstOrDefault(u => u.Id == userId);

            user.Energy++;
            await this.context.SaveChangesAsync();

            return user.Energy;
        }

        public UpdateUserAfterLectureDto UpgradeUserAfterLecture(string userId)
        {
            var user = this.context.Users.Find(userId);
            var userLecture = this.context.UserLectures
                .Include(ul => ul.Lecture.Course)
                .FirstOrDefault(ul => ul.IsActive == true && ul.ProgrammerUserId == userId);

            var dto = new UpdateUserAfterLectureDto();

            if (userLecture.Lecture.Course.Name.Contains("C#"))
            {
                user.CSharp += userLecture.Lecture.Course.HardSkillReward;
                user.ProblemSolving += userLecture.Lecture.Course.SoftSkillReward;
                dto.HardSkill += userLecture.Lecture.Course.HardSkillReward;
                dto.SoftSkill += userLecture.Lecture.Course.SoftSkillReward;
            }
            else if (userLecture.Lecture.Course.Name == "Data Structures")
            {
                user.DataStructures += userLecture.Lecture.Course.HardSkillReward;
                user.AbstractThinking += userLecture.Lecture.Course.SoftSkillReward;
            }
            else if (userLecture.Lecture.Course.Name == "Algorithms")
            {
                user.Algorithms += userLecture.Lecture.Course.HardSkillReward;
                user.AbstractThinking += userLecture.Lecture.Course.SoftSkillReward;
            }
            else if (userLecture.Lecture.Course.Name == "Unit Testing")
            {
                user.Testing += userLecture.Lecture.Course.HardSkillReward;
                user.AbstractThinking += userLecture.Lecture.Course.SoftSkillReward;
            }

            user.Xp += userLecture.Lecture.XpReward;
            user.TaskTimeRemaining = null;
            user.IsActive = false;

            userLecture.IsCompleted = true;
            userLecture.IsActive = false;

            this.context.SaveChanges();

            dto.Xp = user.Xp;
            dto.XpForNextLevel = user.XpForNextLevel;
            dto.IsActive = user.IsActive;
            dto.Level = user.Level;
            dto.TaskTimeRemaining = user.TaskTimeRemaining;

            return dto;
        }
    }
}

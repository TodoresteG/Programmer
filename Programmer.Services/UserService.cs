﻿namespace Programmer.Services
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

        // TODO: Refactor this. Something is wrong here
        public async Task<UpdateUserAfterLectureDto> UpgradeUserAfterLecture(string userId)
        {
            var user = this.context.Users.Find(userId);
            var userLecture = this.context.UserLectures
                .Include(ul => ul.Lecture.Course)
                .FirstOrDefault(ul => ul.IsActive == true && ul.ProgrammerUserId == userId);

            var userType = user.GetType();

            var hardSkill = (double)userType
                 .GetProperty(userLecture.Lecture.Course.HardSkillName)
                 .GetValue(user);

            userType
                .GetProperty(userLecture.Lecture.Course.HardSkillName)
                .SetValue(user, hardSkill + userLecture.Lecture.Course.HardSkillReward);

            var dto = new UpdateUserAfterLectureDto();

            if (userLecture.Lecture.Name.Contains("Exercise"))
            {
                user.Coding += userLecture.Lecture.Course.SoftSkillReward;
                dto.SoftSkillName = "coding";
                dto.SoftSkill = user.Coding;
            }
            else
            {
                var softSkill = (double)userType
                     .GetProperty(userLecture.Lecture.Course.SoftSkillName)
                     .GetValue(user);

                userType
                    .GetProperty(userLecture.Lecture.Course.SoftSkillName)
                    .SetValue(user, softSkill + userLecture.Lecture.Course.SoftSkillReward);

                dto.SoftSkillName = userLecture.Lecture.Course.SoftSkillName.ToLower();
                dto.SoftSkill = (double)userType.GetProperty(userLecture.Lecture.Course.SoftSkillName).GetValue(user);
            }

            user.Xp += userLecture.Lecture.Course.XpReward;

            if (user.Xp >= user.XpForNextLevel)
            {
                user.Level++;
            }

            user.TaskTimeRemaining = null;
            user.IsActive = false;

            userLecture.IsCompleted = true;
            userLecture.IsActive = false;

            await this.context.SaveChangesAsync();

            dto.HardSkill = (double)userType.GetProperty(userLecture.Lecture.Course.HardSkillName).GetValue(user);
            dto.HardSkillName = userLecture.Lecture.Course.HardSkillName.ToLower();
            dto.Level = user.Level;
            dto.Xp = user.Xp;
            dto.XpForNextLevel = user.XpForNextLevel;

            return dto;
        }
    }
}

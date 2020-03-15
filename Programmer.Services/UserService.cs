﻿namespace Programmer.Services
{
    using Microsoft.EntityFrameworkCore;
    using Programmer.App.ViewModels.Users;
    using Programmer.Data;
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private const double BaseSeconds = 6;
        private const double UserXpDivider = 2;

        private readonly ProgrammerDbContext context;

        public UserService(ProgrammerDbContext context)
        {
            this.context = context;
        }

        public PlayerInfoViewModel GetPlayerInfo(string userId)
        {
            var user = this.context.Users
                .Where(u => u.Id == userId)
                .To<PlayerInfoViewModel>()
                .FirstOrDefault();

            return user;
        }

        public DateTime GetTimeNeeded(string userId)
        {
            var userXp = this.context.Users
                .Where(u => u.Id == userId)
                .Select(u => u.Xp)
                .FirstOrDefault();

            var time = TimeSpan.FromSeconds(Math.Round(userXp / UserXpDivider * BaseSeconds)).TotalSeconds;
            return DateTime.Now.AddSeconds(time);
        }

        public UpdateUserAfterLectureApiModel UpdateUserAfterExam(string userId)
        {
            var user = this.context.Users.Find(userId);

            var course = this.context.UserCourses
                .Where(c => c.ProgrammerUserId == userId)
                .FirstOrDefault();

            user.TypeOfTask = null;
            user.IsActive = false;
            user.TaskTimeRemaining = null;

            course.IsCompleted = true;
            course.IsEnrolled = false;

            this.context.SaveChanges();

            var apiModel = this.context.Users
                .Where(u => u.Id == userId)
                .To<UpdateUserAfterLectureApiModel>()
                .FirstOrDefault();

            return apiModel;
        }

        public int UpdateUserEnergy(string userId)
        {
            var user = this.context.Users
                .FirstOrDefault(u => u.Id == userId);

            user.Energy++;
            this.context.SaveChanges();

            return user.Energy;
        }

        // TODO: Refactor this. Something is wrong here
        public UpdateUserAfterLectureApiModel UpgradeUserAfterLecture(string userId)
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

            var dto = new UpdateUserAfterLectureApiModel();

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
            user.TypeOfTask = null;

            userLecture.IsCompleted = true;
            userLecture.IsActive = false;

            this.context.SaveChanges();

            dto.HardSkill = (double)userType.GetProperty(userLecture.Lecture.Course.HardSkillName).GetValue(user);
            dto.HardSkillName = userLecture.Lecture.Course.HardSkillName.ToLower();
            dto.Level = user.Level;
            dto.Xp = user.Xp;
            dto.XpForNextLevel = user.XpForNextLevel;

            return dto;
        }

        private void LevelUp(ProgrammerUser user) 
        {
            user.Level++;

        }
    }
}

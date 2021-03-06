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

        public UpdateUserAfterActivityApiModel UpdateUserAfterDocumentation(string userId)
        {
            var user = this.context.Users.Find(userId);

            var documentation = this.context.UserDocumentations
                .Include(ud => ud.Documentation)
                .Where(ud => ud.ProgrammerId == userId)
                .FirstOrDefault();

            user.TypeOfTask = null;
            user.IsActive = false;
            user.TaskTimeRemaining = null;
            user.Xp += documentation.Documentation.XpReward;

            var userType = user.GetType();

            var hardSkill = (double)userType
                 .GetProperty(documentation.Documentation.HardSkillName)
                 .GetValue(user);

            userType
                .GetProperty(documentation.Documentation.HardSkillName)
                .SetValue(user, hardSkill + documentation.Documentation.HardSkillReward);

            this.context.UserDocumentations.Remove(documentation);
            this.context.SaveChanges();

            var apiModel = this.context.Users
                .Where(u => u.Id == userId)
                .To<UpdateUserAfterActivityApiModel>()
                .FirstOrDefault();

            apiModel.HardSkillName = documentation.Documentation.HardSkillName.ToLower();
            apiModel.HardSkill = (double)userType.GetProperty(documentation.Documentation.HardSkillName).GetValue(user);
            return apiModel;
        }

        public UpdateUserAfterActivityApiModel UpdateUserAfterExam(string userId)
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
                .To<UpdateUserAfterActivityApiModel>()
                .FirstOrDefault();

            return apiModel;
        }

        public int UpdateUserEnergy(string userId)
        {
            var user = this.context.Users
                .FirstOrDefault(u => u.Id == userId);

            if (user.Energy >= 30)
            {
                return 30;
            }

            user.Energy++;
            this.context.SaveChanges();

            return user.Energy;
        }

        // TODO: Refactor this. Something is wrong here
        public UpdateUserAfterActivityApiModel UpdateUserAfterLecture(string userId)
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

            var dto = new UpdateUserAfterActivityApiModel();

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

            this.LevelUp(user);

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
            if (user.Xp >= user.XpForNextLevel)
            {
                user.Level++;
            }
        }
    }
}

namespace Programmer.Services
{
    using Programmer.App.ViewModels.Academy;
    using Programmer.Data;
    using Programmer.Services.Mapping;
    using Programmer.Services.Dtos;
    using Programmer.Services.Extensions.Courses;
    using System.Collections.Generic;
    using System.Linq;
    using Programmer.App.ViewModels.Courses;
    using Programmer.App.ViewModels.Lectures;
    using Programmer.App.ViewModels.Exams;
    using Programmer.Data.Models;
    using System;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AcademyService : IAcademyService
    {
        private readonly ProgrammerDbContext context;

        public AcademyService(ProgrammerDbContext context)
        {
            this.context = context;
        }

        private IEnumerable<bool> CheckCoursesRequiredSkills(string userId)
        {
            var user = this.context.Users
                .Where(u => u.Id == userId)
                .Select(u => new UserStatsViewModel
                {
                    AbstractThinking = u.AbstractThinking,
                    Algorithms = u.Algorithms,
                    AspNetCore = u.AspNetCore,
                    Bitcoins = u.Bitcoins,
                    Coding = u.Coding,
                    Creativity = u.Creativity,
                    CSharp = u.CSharp,
                    Css = u.Css,
                    Curiosity = u.Curiosity,
                    DatabasesAndSQL = u.DatabasesAndSQL,
                    DataStructures = u.DataStructures,
                    EfCore = u.EfCore,
                    Energy = u.Energy,
                    Html = u.Html,
                    IsActive = u.IsActive,
                    Level = u.Level,
                    Money = u.Money,
                    NodeJs = u.NodeJs,
                    ProblemSolving = u.ProblemSolving,
                    React = u.React,
                    Testing = u.Testing,
                    VanillaJavaScript = u.VanillaJavaScript,
                    Xp = u.Xp,
                })
                .FirstOrDefault();

            return CourseExtension.CheckCourses(user);
        }

        // TODO: Make this work with the method above
        public AcademyAllCoursesViewModel GetAllCourses(string userId)
        {
            var test = this.CheckCoursesRequiredSkills(userId);

            // really bad query can't figure other way. It works for now
            var allCourses = this.context.Courses
                .Select(c => new AcademyCourseViewModel 
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    IsCompleted = c.Users.Where(uc => uc.ProgrammerUserId == userId).Select(uc => uc.IsCompleted).FirstOrDefault(),
                    IsEnrolled = c.Users.Where(uc => uc.ProgrammerUserId == userId).Select(uc => uc.IsEnrolled).FirstOrDefault(),
                })
                .ToList();

            var enrolledCourses = this.context.UserCourses
                .Where(u => u.IsEnrolled == true && u.ProgrammerUserId == userId)
                .To<AcademyEnrolledCourseViewModel>()
                .ToList();

            var completedCourses = this.context.UserCourses
                .Where(c => c.IsCompleted == true && c.ProgrammerUserId == userId)
                .To<AcademyCompletedCourseViewModel>()
                .ToList();

            var dto = new AcademyAllCoursesViewModel
            {
                AllCourses = allCourses,
                EnrolledCourses = enrolledCourses,
                CompletedCourses = completedCourses,
            };

            return dto;
        }

        public AdministrationAcademyAllCoursesViewModel GetAllCoursesForAdmin() 
        {
            var allCourses = this.context.Courses
                .To<AdministrationAcademyCourseViewModel>()
                .ToList();

            return new AdministrationAcademyAllCoursesViewModel { Courses = allCourses };
        }

        public AdministrationCourseInfoViewModel CourseInfo(int courseId)
        {
            var lectures = this.context.Lectures
                .Where(l => l.CourseId == courseId)
                .To<AdministrationLectureViewModel>()
                .ToList();

            var exam = this.context.Exams
                .Where(e => e.CourseId == courseId)
                .To<AdministrationExamViewModel>()
                .FirstOrDefault();

            return new AdministrationCourseInfoViewModel
            {
                CourseId = courseId,
                Lectures = lectures,
                Exam = exam,
            };
        }

        public AdministrationCreateCourseInputModel GetSkillsForDropdowns()
        {
            var softSkills = typeof(ProgrammerUser)
                .GetProperties()
                .Where(p => p.PropertyType == typeof(double) && p.Name != "CSharp")
                .Select(p => new SelectListItem(p.Name, p.Name))
                .ToList();

            var hardSkills = typeof(ProgrammerUser)
                .GetProperties()
                .Where(p => p.PropertyType == typeof(double?) || p.Name == "CSharp")
                .Select(p => new SelectListItem(p.Name, p.Name))
                .ToList();

            return new AdministrationCreateCourseInputModel
            {
                HardSkillReward = 1,
                XpReward = 1,
                RequiredEnergy = 1,
                SoftSkillReward = 1,
                HardSkillNames = hardSkills,
                SoftSkillNames = softSkills,
            };
        }

        public void CreateCourse(AdministrationCreateCourseInputModel inputModel)
        {
            var course = new Course
            {
                CreatedOn = DateTime.UtcNow,
                Name = inputModel.Name,
                Price = inputModel.Price,
                HardSkillName = inputModel.HardSkillName,
                HardSkillReward = inputModel.HardSkillReward,
                SoftSkillName = inputModel.SoftSkillName,
                SoftSkillReward = inputModel.SoftSkillReward,
                RequiredEnergy = inputModel.RequiredEnergy,
                XpReward = inputModel.XpReward,
            };

            this.context.Courses.Add(course);
            this.context.SaveChanges();
        }

        public void CreateLecture(string name, int courseId)
        {
            var lecture = new Lecture
            {
                CourseId = courseId,
                CreatedOn = DateTime.UtcNow,
                Name = name,
            };

            this.context.Lectures.Add(lecture);
            this.context.SaveChanges();
        }

        public AdministrationCreateExamInputModel GetRequiredSkillName(int courseId)
        {
            var hardSkillName = this.context.Courses
                .Where(c => c.Id == courseId)
                .Select(c => c.HardSkillName)
                .FirstOrDefault();

            return new AdministrationCreateExamInputModel
            {
                RequiredHardSkillName = hardSkillName,
                CourseId = courseId,
            };
        }

        public void CreateExam(AdministrationCreateExamInputModel inputModel) 
        {
            var exam = new Exam
            {
                CourseId = inputModel.CourseId,
                CreatedOn = DateTime.UtcNow,
                RequiredCodingSkill = inputModel.RequiredCodingSkill,
                RequiredEnergy = inputModel.RequiredEnergy,
                RequiredHardSkill = inputModel.RequiredHardSkill,
                RequiredHardSkillName = inputModel.RequiredHardSkillName,
            };

            this.context.Exams.Add(exam);
            this.context.SaveChanges();
        }
    }
}

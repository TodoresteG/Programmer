namespace Programmer.Services
{
    using Programmer.App.ViewModels.Exams;
    using Programmer.Data;
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;
    using System.Linq;

    public class ExamService : IExamService
    {
        private readonly ProgrammerDbContext context;
        private readonly IUserService userService;

        public ExamService(ProgrammerDbContext context, IUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }

        public ExamDetailsViewModel GetExamDetails(int id, string userId)
        {
            var exam = this.context.Exams
                .Where(e => e.Id == id)
                .To<ExamDetailsViewModel>()
                .FirstOrDefault();

            exam.TimeNeeded = this.userService.GetTimeNeeded(userId).ToString();

            return exam;
        }

        public bool TakeExam(int examId, string userId)
        {
            var exam = this.context.Exams
                .Where(e => e.Id == examId)
                .To<ExamDetailsViewModel>()
                .FirstOrDefault();

            var user = this.context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefault();

            if (!CanTakeExam(user, exam))
            {
                return false;
            }

            user.Energy -= exam.RequiredEnergy;
            user.IsActive = true;
            user.TaskTimeRemaining = this.userService.GetTimeNeeded(userId);
            user.TypeOfTask = "Exam";

            this.context.SaveChanges();
            return true;
        }

        private bool CanTakeExam(ProgrammerUser user, ExamDetailsViewModel exam) 
        {
            var userHardSkill = (double)user.GetType().GetProperty(exam.RequiredHardSkillName).GetValue(user);

            if (user.Energy < exam.RequiredEnergy)
            {
                return false;
            }

            if (userHardSkill < exam.RequiredHardSkill)
            {
                return false;
            }

            if (user.Coding < exam.RequiredCodingSkill)
            {
                return false;
            }

            return true;
        }
    }
}

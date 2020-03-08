namespace Programmer.Services
{
    using Programmer.App.ViewModels.Exams;
    using Programmer.Data;
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
    }
}

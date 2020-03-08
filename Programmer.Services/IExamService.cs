namespace Programmer.Services
{
    using Programmer.App.ViewModels.Exams;

    public interface IExamService
    {
        ExamDetailsViewModel GetExamDetails(int id, string userId);
    }
}

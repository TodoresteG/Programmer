namespace Programmer.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Programmer.Services;
    using System.Security.Claims;

    [Authorize]
    public class ExamsController : Controller
    {
        private readonly IExamService examService;

        public ExamsController(IExamService examService)
        {
            this.examService = examService;
        }

        public IActionResult Details(int examId) 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = this.examService.GetExamDetails(examId, userId);

            return this.View(viewModel);
        }

        public IActionResult Take(int examId) 
        {

        }
    }
}

namespace Programmer.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Programmer.Services;
    using System.Security.Claims;

    public class AcademyController : Controller
    {
        private readonly IAcademyService academyService;

        public AcademyController(IAcademyService academyService)
        {
            this.academyService = academyService;
        }

        [Authorize]
        public IActionResult Index() 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var viewModel = this.academyService.GetAllCourses(userId);

            return this.View(viewModel);
        }
    }
}

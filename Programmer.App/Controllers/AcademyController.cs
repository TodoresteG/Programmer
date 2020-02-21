namespace Programmer.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Programmer.Services;

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
            var viewModel = this.academyService.GetAllCourses();

            return this.View(viewModel);
        }
    }
}

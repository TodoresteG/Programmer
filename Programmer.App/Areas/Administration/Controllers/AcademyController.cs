namespace Programmer.App.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Programmer.Services;

    public class AcademyController : AdministrationController
    {
        private readonly IAcademyService academyService;

        public AcademyController(IAcademyService academyService)
        {
            this.academyService = academyService;
        }

        public IActionResult Index() 
        {
            var viewModel = this.academyService.GetAllCoursesForAdmin();
            return this.View(viewModel);
        }

        public IActionResult CreateCourse() 
        {
            var viewModel = this.academyService.GetSkillsForDropdowns();
            return this.View(viewModel);
        }
    }
}

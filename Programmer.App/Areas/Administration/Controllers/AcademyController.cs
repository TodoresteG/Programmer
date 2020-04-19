namespace Programmer.App.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Programmer.App.ViewModels.Courses;
    using Programmer.App.ViewModels.Exams;
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

        [HttpPost]
        public IActionResult CreateCourse(AdministrationCreateCourseInputModel inputModel) 
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            this.academyService.CreateCourse(inputModel);
            return this.Redirect("/Administration/Academy/Index");
        }

        public IActionResult CreateExam(int id) 
        {
            var viewModel = this.academyService.GetRequiredSkillName(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateExam(AdministrationCreateExamInputModel inputModel) 
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            this.academyService.CreateExam(inputModel);
            return this.Redirect("/Administration/Academy/Index");
        }

        public IActionResult EditExam(int id) 
        {
            var viewModel = this.academyService.GetExamForEdit(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult EditExam(AdministrationCreateExamInputModel inputModel) 
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            this.academyService.EditExam(inputModel);
            return this.Redirect("/Administration/Academy/Index");
        }
    }
}

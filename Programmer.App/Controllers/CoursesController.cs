using Microsoft.AspNetCore.Authorization;
namespace Programmer.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Programmer.Services;

    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [Authorize]
        public IActionResult Enroll(int id) 
        {
            var viewModel = this.courseService.GetCourseDetails(id);

            return this.View(viewModel);
        }
    }
}

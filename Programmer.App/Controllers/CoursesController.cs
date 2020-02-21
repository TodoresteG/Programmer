namespace Programmer.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Programmer.Services;
    using System.Security.Claims;

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

        [Authorize]
        public IActionResult EnrollOnACourse(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            this.courseService.EnrollUserToCourse(id, userId);

            return this.Redirect("/Academy/Index");
        }
    }
}

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
            var viewModel = this.courseService.GetCourseEnrollDetails(id);

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult EnrollOnACourse(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            this.courseService.EnrollUserToCourse(id, userId);

            return this.Redirect("/Academy/Index");
        }

        [Authorize]
        public IActionResult Details(int id) 
        {
            // TODO: Make after you enroll on a course to deactivate enrolling on the same one.
            // TODO: Make taking a lecture to be in order of the course lectures

            var viewModel = this.courseService.GetCourseDetails(id);

            return this.View(viewModel);
        }
    }
}

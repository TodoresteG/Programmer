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
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var isEnrolled = this.courseService.IsEnrolled(id, userId);

            if (isEnrolled)
            {
                return this.Redirect("/Academy/Index");
            }

            var viewModel = this.courseService.GetCourseEnrollDetails(id);

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult EnrollOnACourse(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var isEnrolled = this.courseService.EnrollUserToCourse(id, userId);

            if (!isEnrolled)
            {
                // TODO: Make a better error
                return this.Content("Not enough money to enroll on a course");
            }

            return this.Redirect("/Academy/Index");
        }

        [Authorize]
        public IActionResult Details(int id) 
        {
            // TODO: Make taking a lecture to be in order of the course lectures

            var viewModel = this.courseService.GetCourseDetails(id);

            return this.View(viewModel);
        }
    }
}

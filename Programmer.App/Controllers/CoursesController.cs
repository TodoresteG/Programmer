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
            var isCompleted = this.courseService.IsCompleted(id, userId);

            if (isEnrolled || isCompleted)
            {
                return this.Redirect("/Academy/Index");
            }

            var viewModel = this.courseService.GetCourseEnrollDetails(id, userId);

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult EnrollOnACourse(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!this.courseService.IsPreviousCompleted(id, userId))
            {
                return this.Redirect("/Academy/Index");
            }

            var isEnrolled = this.courseService.EnrollUserToCourse(id, userId);
            if (!isEnrolled)
            {
                // TODO: Make a better error. Make this validation on client side
                return this.Content("Not enough money to enroll on a course");
            }

            return this.Redirect("/Academy/Index");
        }

        [Authorize]
        public IActionResult Details(int id) 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = this.courseService.GetCourseDetails(id, userId);

            return this.View(viewModel);
        }
    }
}

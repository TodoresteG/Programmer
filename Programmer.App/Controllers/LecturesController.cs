namespace Programmer.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Programmer.Services;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class LecturesController : Controller
    {
        private readonly ILectureService lectureService;

        public LecturesController(ILectureService lectureService)
        {
            this.lectureService = lectureService;
        }

        [Authorize]
        public IActionResult Details(int lectureId) 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = this.lectureService.GetLectureDetails(lectureId, userId);

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Watch(int lectureId) 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            this.lectureService.WatchLecture(lectureId, userId);

            return this.Redirect("/Home/Office");
        }

        [Authorize]
        public IActionResult UpdateUser() 
        {


            return this.Redirect("Home/Office");
        }
    }
}

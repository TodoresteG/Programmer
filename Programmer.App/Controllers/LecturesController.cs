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
            var viewModel = this.lectureService.GetLectureDetails(lectureId);

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Watch(int lectureId) 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.lectureService.WatchLecture(lectureId, userId);

            return this.Redirect("/Home/Office");
        }
    }
}

namespace Programmer.App.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Programmer.App.ViewModels.Courses;
    using Programmer.Services;

    [Route("api/admin/[controller]")]
    [ApiController]
    public class AcademyApiController : ControllerBase
    {
        private readonly IAcademyService academyService;

        public AcademyApiController(IAcademyService academyService)
        {
            this.academyService = academyService;
        }

        [HttpGet("GetCourseInfo/{id}")]
        public ActionResult<AdministrationCourseInfoViewModel> GetCourseInfo(int id)
        {
            var viewModel = this.academyService.CourseInfo(id);
            return viewModel;
        }

        [HttpPost("CreateLecture/{courseId}")]
        public ActionResult<bool> CreateLecture(int courseId) 
        {
            var lectureName = this.HttpContext.Request.Form["name"][0];
            if (string.IsNullOrWhiteSpace(lectureName) || lectureName.Length < 3)
            {
                return false;
            }

            this.academyService.CreateLecture(lectureName, courseId);
            return true;
        }
    }
}

namespace Programmer.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Programmer.App.ViewModels.Users;
    using Programmer.Services;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class UsersController : ApiController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("UpdateUserAfterLecture")]
        public ActionResult<int> UpdateUserAfterLecture() 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            int userEnergy = this.userService.UpdateUserEnergy(userId);

            return userEnergy;
        }

        [HttpGet("UpdateUserStats")]
        public ActionResult<UpdateUserAfterLectureApiModel> UpdateUserStats() 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var apiModel = this.userService.UpgradeUserAfterLecture(userId);

            return apiModel;
        }

        [HttpGet("UpdateUserAfterExam")]
        public void UpdateUserAfterExam() 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            this.userService.UpdateUserAfterExam(userId);
        }
    }
}

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

        [HttpGet("UpdateUserEnergy")]
        public ActionResult<int> UpdateUserEnergy() 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            int userEnergy = this.userService.UpdateUserEnergy(userId);

            return userEnergy;
        }

        [HttpGet("UpdateUserAfterLecture")]
        public ActionResult<UpdateUserAfterActivityApiModel> UpdateUserAfterLecture() 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var apiModel = this.userService.UpgradeUserAfterLecture(userId);

            return apiModel;
        }

        [HttpGet("UpdateUserAfterExam")]
        public ActionResult<UpdateUserAfterActivityApiModel> UpdateUserAfterExam() 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return this.userService.UpdateUserAfterExam(userId);
        }

        [HttpGet("UpdateUserAfterDocumentation")]
        public ActionResult<UpdateUserAfterActivityApiModel> UpdateUserAfterDocumentation() 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return this.userService.UpdateUserAfterDocumentation(userId);
        }
    }
}

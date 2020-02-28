namespace Programmer.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Programmer.App.Models.Users;
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
        public async Task<ActionResult<int>> UpdateUserEnergy() 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            int userEnergy = await this.userService.UpdateUserEnergy(userId);

            return userEnergy;
        }

        [HttpGet("UpdateUserStats")]
        public async Task<ActionResult<UpdateUserAfterLectureApiModel>> UpdateUserStats() 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var dto = await this.userService.UpgradeUserAfterLecture(userId);

            var apiModel = new UpdateUserAfterLectureApiModel
            {
                HardSkill = dto.HardSkill,
                HardSkillName = dto.HardSkillName,
                SoftSkill = dto.SoftSkill,
                SoftSkillName = dto.SoftSkillName,
                Level = dto.Level,
                Xp = dto.Xp,
                XpForNextLevel = dto.XpForNextLevel,
            };

            return apiModel;
        }
    }
}

namespace Programmer.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{UpdateUserEnergy}")]
        public async Task<ActionResult<int>> UpdateUserEnergy() 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            int userEnergy = await this.userService.UpdateUserEnergy(userId);

            return userEnergy;
        }
    }
}

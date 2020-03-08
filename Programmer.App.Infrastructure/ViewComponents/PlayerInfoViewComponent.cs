namespace Programmer.App.Infrastructure.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using Programmer.App.ViewModels.Users;
    using Programmer.Services;
    using System.Security.Claims;

    [ViewComponent(Name = "PlayerInfo")]
    public class PlayerInfoViewComponent : ViewComponent
    {
        private readonly IUserService userService;

        public PlayerInfoViewComponent(IUserService userService)
        {
            this.userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            var userId = this.UserClaimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = this.userService.GetPlayerInfo(userId);

            return this.View(viewModel);
        }
    }
}

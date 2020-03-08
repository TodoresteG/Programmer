namespace Programmer.App.ViewComponents
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
            var dto = this.userService.GetPlayerInfo(userId);

            var viewModel = new PlayerInfoViewModel
            {
                Bitcoins = dto.Bitcoins,
                Energy = dto.Energy,
                IsActive = dto.IsActive,
                Level = dto.Level,
                Money = dto.Money,
                TimeRemaining = dto.TimeRemaining,
                Xp = dto.Xp,
                XpForNextLevel = dto.XpForNextLevel,
            };

            return this.View(viewModel);
        }
    }
}

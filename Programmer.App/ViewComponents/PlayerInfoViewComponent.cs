namespace Programmer.App.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using Programmer.App.Models.Users;
    using Programmer.Services;

    public class PlayerInfoViewComponent : ViewComponent
    {
        private readonly IUserService userService;

        public PlayerInfoViewComponent(IUserService userService)
        {
            this.userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new PlayerInfoViewModel();
            return this.View(viewModel);
        }
    }
}

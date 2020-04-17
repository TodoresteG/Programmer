namespace ProgrammerDemo.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Programmer.App.ViewModels.Office;
    using Programmer.Services;
    using Programmer.App.ViewModels;
    using System.Security.Claims;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOfficeService officeService;

        public HomeController(ILogger<HomeController> logger, IOfficeService officeService)
        {
            _logger = logger;
            this.officeService = officeService;
        }

        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Home/Office");
            }

            return View();
        }

        [Authorize]
        public IActionResult Office()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = this.officeService.GetUserForHome(userId);

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

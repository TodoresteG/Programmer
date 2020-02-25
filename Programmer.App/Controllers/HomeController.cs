using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Programmer.App.Models.Office;
using Programmer.Services;
using ProgrammerDemo.Models;

namespace ProgrammerDemo.Controllers
{
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
            var user = this.officeService.GetUserForHome(this.User.Identity.Name);

            OfficeViewModel viewModel = new OfficeViewModel
            {
                Xp = user.Xp,
                XpForNextLevel = user.XpForNextLevel,
                Bitcoins = user.Bitcoins,
                Energy = user.Energy,
                Level = user.Level,
                Money = user.Money,
                UserStats = user.UserStats,
                TimeRemaining = user.TimeRemaining,
            };

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

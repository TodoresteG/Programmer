﻿namespace Programmer.App.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : AdministrationController
    {
        public IActionResult Index() 
        {
            return this.View();
        }
    }
}

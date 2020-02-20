namespace Programmer.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class AcademyController : Controller
    {
        [Authorize]
        public IActionResult Index() 
        {
            return this.View();
        }
    }
}

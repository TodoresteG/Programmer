namespace Programmer.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class LecturesController : Controller
    {
        public IActionResult Details(int lectureId) 
        {
            return this.View();
        }
    }
}

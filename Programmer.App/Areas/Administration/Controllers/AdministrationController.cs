namespace Programmer.App.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class AdministrationController : Controller
    {
    }
}

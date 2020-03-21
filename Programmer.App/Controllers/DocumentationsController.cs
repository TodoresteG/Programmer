namespace Programmer.App.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Programmer.Services;

    [Authorize]
    public class DocumentationsController : Controller
    {
        private readonly IDocumentationService documentationService;

        public DocumentationsController(IDocumentationService documentationService)
        {
            this.documentationService = documentationService;
        }

        public IActionResult Index() 
        {
            var viewModel = this.documentationService.GetDocumentationsForIndex();
            return this.View(viewModel);
        }

        public IActionResult Read(int id) 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var canRead = this.documentationService.ReadDocumentation(id, userId);

            if (!canRead)
            {
                return this.Content("Not enough energy to read documentation");
            }

            return this.Redirect("/Home/Office");
        }
    }
}

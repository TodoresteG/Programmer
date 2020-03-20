namespace Programmer.App.Controllers
{
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
    }
}

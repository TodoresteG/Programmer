namespace Programmer.Services
{
    using System.Linq;
    using Programmer.App.ViewModels.Documentations;
    using Programmer.Data;
    using Programmer.Services.Mapping;

    public class DocumentationService : IDocumentationService
    {
        private readonly ProgrammerDbContext context;

        public DocumentationService(ProgrammerDbContext context)
        {
            this.context = context;
        }

        public AllDocumentationsIndexViewModel GetDocumentationsForIndex()
        {
            var documentations = this.context.Documentations
                .To<DocumentationIndexViewModel>()
                .ToList();

            return new AllDocumentationsIndexViewModel { Documentations = documentations };
        }
    }
}

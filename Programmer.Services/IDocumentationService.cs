namespace Programmer.Services
{
    using Programmer.App.ViewModels.Documentations;

    public interface IDocumentationService
    {
        AllDocumentationsIndexViewModel GetDocumentationsForIndex();
    }
}

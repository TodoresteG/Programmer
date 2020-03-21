namespace Programmer.Services
{
    using System;
    using System.Linq;
    using Programmer.App.ViewModels.Documentations;
    using Programmer.Data;
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;

    public class DocumentationService : IDocumentationService
    {
        private readonly ProgrammerDbContext context;
        private readonly IUserService userService;

        public DocumentationService(ProgrammerDbContext context, IUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }

        public AllDocumentationsIndexViewModel GetDocumentationsForIndex()
        {
            var documentations = this.context.Documentations
                .To<DocumentationIndexViewModel>()
                .ToList();

            return new AllDocumentationsIndexViewModel { Documentations = documentations };
        }

        public bool ReadDocumentation(int documentationId, string userId)
        {
            var documentation = this.context.Documentations.Find(documentationId);
            var user = this.context.Users.FirstOrDefault(u => u.Id == userId);

            if (user.Energy < documentation.RequiredEnergy)
            {
                return false;
            }

            user.Energy -= documentation.RequiredEnergy;
            user.IsActive = true;
            user.TaskTimeRemaining = this.userService.GetTimeNeeded(userId);
            user.TypeOfTask = "Documentation";

            var userDocumentation = new UserDocumentation
            {
                DocumentationId = documentationId,
                ProgrammerId = userId,
            };

            this.context.UserDocumentations.Add(userDocumentation);
            this.context.SaveChanges();
            return true;
        }
    }
}

namespace Programmer.App.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Programmer.App.ViewModels.Administration;
    using Programmer.Services;

    public class AccountsController : AdministrationController
    {
        private readonly IAdministrationService administrationService;

        public AccountsController(IAdministrationService administrationService)
        {
            this.administrationService = administrationService;
        }

        public IActionResult ManageAccounts() 
        {
            var viewModel = this.administrationService.GetAllUserNames();
            return this.View(viewModel);
        }

        public IActionResult MakeUserAdmin(string users) 
        {
            this.administrationService.MakeUserAdmin(users);
            return this.Redirect("/Administration/Accounts/ManageAccounts");
        }
    }
}

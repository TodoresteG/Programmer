namespace Programmer.Services
{
    using System.Linq;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Programmer.App.ViewModels.Administration;
    using Programmer.Data;
    using Programmer.Data.Models;

    public class AdministrationService : IAdministrationService
    {
        private readonly ProgrammerDbContext context;
        private readonly UserManager<ProgrammerUser> userManager;

        public AdministrationService(ProgrammerDbContext context, UserManager<ProgrammerUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public ManageAccountsViewModel GetAllUserNames()
        {
            var usernames = this.context.Users
                .Select(u => new SelectListItem(u.UserName, u.UserName))
                .ToList();

            return new ManageAccountsViewModel { Users = usernames };
        }

        public void MakeUserAdmin(string username)
        {
            var user = this.context.Users
                .FirstOrDefault(u => u.UserName == username);

            this.userManager.AddToRoleAsync(user, "Administrator").GetAwaiter().GetResult();
            this.context.SaveChanges();
        }
    }
}

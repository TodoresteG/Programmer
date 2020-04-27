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

        public ManageAccountsViewModel GetAllUserNames(string adminName)
        {
            var usernames = this.context.Users
                .Where(u => u.UserName != adminName)
                .Select(u => new SelectListItem(u.UserName, u.UserName))
                .ToList();

            var administrators = this.userManager
                .GetUsersInRoleAsync("Administrator")
                .Result
                .Select(u => u.UserName);

            return new ManageAccountsViewModel 
            { 
                Users = usernames,
                Admins = administrators,
            };
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

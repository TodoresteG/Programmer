namespace Programmer.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Programmer.Data.Models;

    public class RoleSeeder : ISeeder
    {
        public async Task SeedAsync(ProgrammerDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ProgrammerRole>>();

            await SeedRoleAsync(roleManager, "Administrator");
        }

        private static async Task SeedRoleAsync(RoleManager<ProgrammerRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new ProgrammerRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}

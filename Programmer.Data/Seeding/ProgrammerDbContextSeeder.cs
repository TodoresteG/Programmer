namespace Programmer.Data.Seeding
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Programmer.Data.Models;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProgrammerDbContextSeeder
    {
        private readonly ProgrammerDbContext context;
        private readonly UserManager<ProgrammerUser> userManager;

        public ProgrammerDbContextSeeder(
            ProgrammerDbContext context,
            UserManager<ProgrammerUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task SeedDb()
        {
            if (this.context.Roles.Any())
            {
                return;
            }

            this.context.Database.Migrate();

            var path = "wwwroot/seed/ProgrammerDBSeeder.sql";
            var seedingScript = File.ReadAllText(path);
            this.context.Database.ExecuteSqlRaw(seedingScript);
            await this.SeedAdmin();
            this.context.SaveChanges();
        }

        private async Task SeedAdmin() 
        {
            var admin = new ProgrammerUser { UserName = "Admin Pesho" };
            var result = await this.userManager.CreateAsync(admin, "asdasd");

            if (result.Succeeded)
            {
                this.context.Users.Add(admin);
                await this.userManager.AddToRoleAsync(admin, "Administrator");
            }
        }
    }
}

namespace Programmer.Data.Seeding
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.DependencyInjection;
    using Programmer.Data.Models;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProgrammerDbContextSeeder
    {
        private readonly ProgrammerDbContext context;
        private readonly IServiceProvider serviceProvider;

        public ProgrammerDbContextSeeder(
            ProgrammerDbContext context,
            IServiceProvider serviceProvider)
        {
            this.context = context;
            this.serviceProvider = serviceProvider;
        }

        public async Task SeedDb()
        {
            var isDbCreated = (this.context.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists();

            if (isDbCreated)
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
            var roleSeeder = new RoleSeeder();
            await roleSeeder.SeedAsync(this.context, this.serviceProvider);

            var admin = new ProgrammerUser { UserName = "Admin" };
            var userManager = this.serviceProvider.GetRequiredService<UserManager<ProgrammerUser>>();
            var result = await userManager.CreateAsync(admin, "asdasd");

            if (result.Succeeded)
            {
                this.context.Users.Add(admin);
                await userManager.AddToRoleAsync(admin, "Administrator");
                await this.context.SaveChangesAsync();
            }
        }
    }
}

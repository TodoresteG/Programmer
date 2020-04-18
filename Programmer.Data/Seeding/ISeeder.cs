namespace Programmer.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(ProgrammerDbContext dbContext, IServiceProvider serviceProvider);
    }
}

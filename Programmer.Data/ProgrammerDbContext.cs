namespace Programmer.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Programmer.Models;

    public class ProgrammerDbContext : IdentityDbContext<ProgrammerUser, ProgrammerRole, string>
    {
        public ProgrammerDbContext(DbContextOptions<ProgrammerDbContext> options)
            : base(options)
        {
        }
    }
}

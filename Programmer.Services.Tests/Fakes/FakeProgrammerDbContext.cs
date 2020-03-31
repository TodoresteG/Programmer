namespace Programmer.Services.Tests.Fakes
{
    using Microsoft.EntityFrameworkCore;
    using Programmer.Data;

    public class FakeProgrammerDbContext
    {
        public FakeProgrammerDbContext(string name)
        {
            var options = new DbContextOptionsBuilder<ProgrammerDbContext>()
               .UseInMemoryDatabase(name)
               .Options;

            this.Data = new ProgrammerDbContext(options);
        }

        public ProgrammerDbContext Data { get; }

        public void Add(params object[] data) 
        {
            this.Data.AddRange(data);
            this.Data.SaveChanges();
        }
    }
}

﻿namespace Programmer.Data.Seeding
{
    using Microsoft.EntityFrameworkCore;
    using System.IO;
    using System;

    public class ProgrammerDbContextSeeder
    {
        private readonly ProgrammerDbContext context;

        public ProgrammerDbContextSeeder(ProgrammerDbContext context)
        {
            this.context = context;
        }

        public void SeedDb()
        {
            this.context.Database.Migrate();

            var path = "wwwroot/seed/ProgrammerDBSeeder.sql";
            var seedingScript = File.ReadAllText(path);
            this.context.Database.ExecuteSqlRaw(seedingScript);
            this.context.SaveChanges();
        }
    }
}

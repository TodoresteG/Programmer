namespace Programmer.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Programmer.Models;
    using System.Reflection;

    public class ProgrammerDbContext : IdentityDbContext<ProgrammerUser, ProgrammerRole, string>
    {
        public ProgrammerDbContext(DbContextOptions<ProgrammerDbContext> options)
            : base(options)
        {
        }

        public DbSet<AdditionalActivityCategory> AdditionalActivityCategories { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Documentation> Documentations { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<JobTask> JobTasks { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<RequiredSkill> RequiredSkills { get; set; }

        public DbSet<UserCourse> UserCourses { get; set; }

        public DbSet<UserLecture> UserLectures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}

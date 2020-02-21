namespace Programmer.Data.Configurations
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> course)
        {
            course
                .HasMany(c => c.Users)
                .WithOne(u => u.Course)
                .HasForeignKey(u => u.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            course
                .HasMany(c => c.Lectures)
                .WithOne(l => l.Course)
                .HasForeignKey(l => l.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            course
                .HasOne(c => c.Exam)
                .WithOne(e => e.Course)
                .HasForeignKey<Exam>(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

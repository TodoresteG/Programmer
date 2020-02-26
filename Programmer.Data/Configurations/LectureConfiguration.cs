namespace Programmer.Data.Configurations
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LectureConfiguration : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> lecture)
        {
            lecture
                .HasMany(l => l.UserLectures)
                .WithOne(ul => ul.Lecture)
                .HasForeignKey(ul => ul.LectureId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

namespace Programmer.Data.Configurations
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserCourseConfiguration : IEntityTypeConfiguration<UserCourse>
    {
        public void Configure(EntityTypeBuilder<UserCourse> userCourse)
        {
            userCourse
                .HasKey(uc => new { uc.ProgrammerUserId, uc.CourseId });
        }
    }
}

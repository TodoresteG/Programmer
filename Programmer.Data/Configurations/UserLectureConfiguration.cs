namespace Programmer.Data.Configurations
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserLectureConfiguration : IEntityTypeConfiguration<UserLecture>
    {
        public void Configure(EntityTypeBuilder<UserLecture> userLecture)
        {
            userLecture
                .HasKey(ul => new { ul.ProgrammerUserId, ul.LectureId });
        }
    }
}

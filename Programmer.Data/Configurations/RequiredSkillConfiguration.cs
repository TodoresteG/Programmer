namespace Programmer.Data.Configurations
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ReqiredSkillConfiguration : IEntityTypeConfiguration<RequiredSkill>
    {
        public void Configure(EntityTypeBuilder<RequiredSkill> requiredSkill)
        {
            requiredSkill
                .HasMany(rs => rs.JobTasks)
                .WithOne(jt => jt.RequiredSkills)
                .HasForeignKey(jt => jt.RequiredSkillId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

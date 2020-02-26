namespace Programmer.Data.Configurations
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PlayerConfiguration : IEntityTypeConfiguration<ProgrammerUser>
    {
        public void Configure(EntityTypeBuilder<ProgrammerUser> player)
        {
            player
                .HasMany(p => p.Courses)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.ProgrammerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            player
                .HasMany(p => p.UserLectures)
                .WithOne(ul => ul.User)
                .HasForeignKey(ul => ul.ProgrammerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            player
                .HasMany(p => p.Events)
                .WithOne(e => e.Player)
                .HasForeignKey(e => e.ProgrammerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            player
                .HasMany(p => p.Documentations)
                .WithOne(d => d.Player)
                .HasForeignKey(d => d.ProgrammerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            //player
            //    .HasMany(p => p.OfficeEquipment)
            //    .WithOne(oe => oe.Player)
            //    .HasForeignKey(oe => oe.PlayerId)
            //    .OnDelete(DeleteBehavior.Restrict);

            player
                .HasMany(p => p.JobTasks)
                .WithOne(jt => jt.Player)
                .HasForeignKey(jt => jt.ProgrammerUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

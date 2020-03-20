namespace Programmer.Data.Configurations
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DocumentationConfiguration : IEntityTypeConfiguration<Documentation>
    {
        public void Configure(EntityTypeBuilder<Documentation> documentation)
        {
            documentation
                .HasMany(d => d.UserDocumentations)
                .WithOne(ud => ud.Documentation)
                .HasForeignKey(ud => ud.DocumentationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

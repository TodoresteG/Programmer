namespace Programmer.Data.Configurations
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserDocumentationConfiguration : IEntityTypeConfiguration<UserDocumentation>
    {
        public void Configure(EntityTypeBuilder<UserDocumentation> userDocumenation)
        {
            userDocumenation
                .HasKey(ud => new { ud.ProgrammerId, ud.DocumentationId });
        }
    }
}

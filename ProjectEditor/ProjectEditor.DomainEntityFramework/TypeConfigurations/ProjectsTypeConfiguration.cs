using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEditor.Domain.Entities;
using SIRS.VM.DomainEntityFramework;

namespace ProjectEditor.DomainEntityFramework.TypeConfiguration
{
    internal class ProjectsTypeConfiguration : IEntityTypeConfiguration<Projects>
    {
        public void Configure(EntityTypeBuilder<Projects> builder)
        {
            builder.Property(x => x.Id).IsRequired();

            builder.HasMany(x => x.Workers)
                   .WithMany(x => x.Projects);

            builder.ToTable(nameof(Projects), Schemes.Public);
        }
    }
}

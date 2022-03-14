using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEditor.Domain.Entities;
using SIRS.VM.DomainEntityFramework;

namespace ProjectEditor.DomainEntityFramework.TypeConfigurations
{
    internal class WorkersTypeConfiguration : IEntityTypeConfiguration<Workers>
    {
        public void Configure(EntityTypeBuilder<Workers> builder)
        {
            builder.Property(x => x.Id).IsRequired();

            builder.HasMany(x => x.Projects)
                   .WithMany(x => x.Workers);

            builder.ToTable(nameof(Workers), Schemes.Public);
        }
    }
}

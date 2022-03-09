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
            builder.Property<Guid>("ProjectWorkerId");

            builder.HasOne(x => x.ProjectWorker)
                   .WithOne(x => x.Projects)
                   .HasForeignKey<Projects>("ProjectWorkerId")
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(nameof(Projects), Schemes.Public).HasKey(p => p.Id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEditor.Domain.Entities;
using ProjectEditor.Domain.Entities.SharedKarnel;
using SIRS.VM.DomainEntityFramework;

namespace ProjectEditor.DomainEntityFramework.TypeConfigurations
{
    internal class ProjectWorkerTypeConfiguration : IEntityTypeConfiguration<ProjectWorker>
    {
        public void Configure(EntityTypeBuilder<ProjectWorker> builder)
        {
            builder.Property<int>("ProjectId");
            builder.Property<int>("WorkerId");

            builder.HasOne(x => x.Workers)
                   .WithOne(x => x.ProjectWorker)
                   .HasForeignKey<ProjectWorker>("WorkerId")
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Projects)
                   .WithOne(x => x.ProjectWorker)
                   .HasForeignKey<ProjectWorker>("ProjectId")
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(nameof(ProjectWorker), Schemes.Public).HasKey(p => p.Id); ;
        }
    }
}

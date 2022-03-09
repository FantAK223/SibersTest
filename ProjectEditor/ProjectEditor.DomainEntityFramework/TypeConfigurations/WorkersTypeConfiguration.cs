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
            builder.Property<Guid>("ProjectId");

            builder.HasOne(x => x.ProjectWorker)
                   .WithOne(x => x.Workers)
                   .HasForeignKey<Workers>("ProjectId")
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(nameof(Workers), Schemes.Public).HasKey(p => p.Id);
        }
    }
}

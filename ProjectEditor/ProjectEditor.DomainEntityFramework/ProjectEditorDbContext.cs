using Microsoft.EntityFrameworkCore;

namespace ProjectEditor.DomainEntityFramework
{
    public class ProjectEditorDbContext : DbContext
    {
        public ProjectEditorDbContext(DbContextOptions options)
            : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasPostgresExtension("uuid-ossp");
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}

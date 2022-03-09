using Microsoft.EntityFrameworkCore;
using ProjectEditor.Config;
using ProjectEditor.DomainEntityFramework;

namespace ProjectEditor.DomainEntityFramework
{
    public class ProjectEditorDbContextFactory
    {
        private readonly DbContextOptions<ProjectEditorDbContext> dbContextOptions;

        public ProjectEditorDbContextFactory(DbContextOptions<ProjectEditorDbContext> options)
        {
            dbContextOptions = options;
        }

        public ProjectEditorDbContext CreateAsApplication() => new ProjectEditorDbContext(dbContextOptions);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectEditor.Config;
using ProjectEditor.DomainEntityFramework;

namespace ProjectEditor.Web
{
    internal static partial class StartupExtensions
    {
        internal static IServiceCollection AddSirsAppEntityFramework(this IServiceCollection services, ProjectEditorConfiguration configuration)
        {
            return services
                    .AddScoped(p =>
                    {
                        var options = p.GetService<DbContextOptions<ProjectEditorDbContext>>();
                        return new ProjectEditorDbContextFactory(options);
                    })
                    .AddDbContext<ProjectEditorDbContext>(options => options.UseNpgsql(configuration.ConnectionString.DefaultConnection))
                    ;
        }
    }
}
using ProjectEditor.ApplicationServices.Services;

namespace ProjectEditor.Web
{
    internal static partial class StartupExtensions
    {
        internal static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ProjectsService>()
                    .AddScoped<WorkersService>()
                ;

            return services;
        }
    }
}
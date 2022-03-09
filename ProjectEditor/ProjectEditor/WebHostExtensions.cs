using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SIRS.VM.DomainEntityFramework;
using System;
using System.Linq;
using ProjectEditor.DomainEntityFramework;
using Serilog;
using ProjectEditor.Domain.Entities;

namespace ProjectEditor.Web
{
    internal static class WebHostExtensions
    {
        public static IWebHost InitializeDatabase(this IWebHost host)
        {
            RollOutDatabaseMigrations();

            return host;

            void RollOutDatabaseMigrations()
            {
                try
                {
                    using (var scope = host.Services.CreateScope())
                    {
                        var factory = scope.ServiceProvider.GetRequiredService<ProjectEditorDbContextFactory>();

                        Log.Information("Database creating...");
                        using (var context = factory.CreateAsApplication())
                        {
                            context.Database.EnsureDeleted();
                            context.Database.EnsureCreated();
                        }
                        Log.Information("Database created.");
                    }
                }
                catch (Exception exception)
                {
                    throw new Exception("An error occurred during rolling up new database schema", exception);
                }
            }
        }

        public static IWebHost SeedDatabase(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var factory = scope.ServiceProvider.GetRequiredService<ProjectEditorDbContextFactory>();

                using (var context = factory.CreateAsApplication())
                {
                    /*var worker1 = new Workers(Guid.NewGuid(), "Sergey", "Nikolaev", "Mihailovich", "seregey1990@mail.ru", "staffer", new ProjectWorker(Guid.NewGuid(),))

                    var project1 = new Projects(Guid.NewGuid(), "MachineLearning", "Mizzenit", "Sibers", DateTime.UtcNow, DateTime.UtcNow, 0, worker1);


                    context.Set<Projects>().AddRange(project1);
                    context.SaveChanges(); 


                    context.Set<Workers>().AddRange(worker1);
                    context.SaveChanges();*/

                }
            }

            return host;
        }
    }
}
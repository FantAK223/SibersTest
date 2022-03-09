using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using System;
using AutoMapper;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;
using ProjectEditor.Config;

namespace ProjectEditor.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration.Get<ProjectEditorConfiguration>();

        public ProjectEditorConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                //TODO need investigation how register config to IoC
                .AddSingleton(provider => Configuration)
                .RegisterApplicationServices()
                .AddSirsAppEntityFramework(Configuration)
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .AddScoped<IMapper>(provider => new Mapper(provider.GetRequiredService<IConfigurationProvider>(), provider.GetService))
                ;

            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "vm/dist"; });

            // Enable CORS
            services.AddCors(options =>
                             {
                                 options.AddDefaultPolicy(builder =>
                                                              builder.SetIsOriginAllowed(_ => true)
                                                                     .AllowAnyMethod()
                                                                     .AllowAnyHeader()
                                                                     .AllowCredentials());
                             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfigurationProvider configurationProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Check Automapper configuration
                configurationProvider.AssertConfigurationIsValid();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
                                   {
                                       OnPrepareResponse = context => { context.Context.Response.Headers[HeaderNames.CacheControl] = "must-revalidate"; }
                                   });
            app.UseSpaStaticFiles();
            app.Use(async (context, next) =>
                    {
                        // Disable caching all GET or HEAD requests
                        if (HttpMethods.IsGet(context.Request.Method) || HttpMethods.IsHead(context.Request.Method))
                        {
                            context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue
                                                                                  {
                                                                                      NoStore = true,
                                                                                      NoCache = true
                                                                                  };
                        }

                        await next.Invoke();
                        });
            app.UseRouting();

            app.UseEndpoints(endpoints =>
                             {
                                 endpoints.MapControllerRoute(
                                                              name: "default",
                                                              pattern: "{controller}/{action=Index}/{id?}");
                             });

            app.UseSpa(spa =>
                       {
                           spa.Options.SourcePath = "pe";

                           if (env.IsDevelopment())
                           {
                               spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
                           }
                       });
        }
    }
}
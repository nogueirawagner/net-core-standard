using AutoMapper;
using Core.Domain.Interfaces;
using Core.Infra.Bus;
using Core.Infra.Identity.Data;
using Core.Infra.Identity.Models;
using Core.Infra.Identity.Services;
using Core.Infra.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Core.Site
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

      if (env.IsDevelopment())
      {
        // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
        builder.AddUserSecrets<Startup>();
      }

      builder.AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // Add framework services.
      services.AddDbContext<IdentityContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("LocalConnection")));

      services.AddIdentity<ApplicationUser, IdentityRole>()
          .AddEntityFrameworkStores<IdentityContext>()
          .AddDefaultTokenProviders();

      services.AddMvc();
      services.AddAutoMapper();

      // Add application services.
     

      RegisterServices(services);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, 
                          IHostingEnvironment env, 
                          ILoggerFactory loggerFactory,
                          IHttpContextAccessor accessor)
    {
      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseBrowserLink();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseStaticFiles();

      app.UseIdentity();

      // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
      });

      InMemoryBus.ContainerAccessor = () => accessor.HttpContext.RequestServices;
    }

    private static void RegisterServices(IServiceCollection services)
    {
      NativeInjectorBootstraper.RegisterServices(services);
    }
  }
}

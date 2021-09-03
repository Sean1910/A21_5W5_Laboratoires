using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AppDependencyInject_Lab.Models;
using AppDependencyInject_Lab.Data;
using AppDependencyInject_Lab.Middleware;
using AppDependencyInject_Lab.Utility.DI_Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using AppDependencyInject_Lab.Utility.AppSettingsClasses;
using AppDependencyInject_Lab.Service;
using AppDependencyInject_Lab.Service.LifeTimeExample;

namespace AppDependencyInject_Lab
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ApplicationDbContext>(options =>
      {
        options.UseSqlServer(Configuration.GetConnectionString("ZombiePartyContext"));
      });

      #region Enregistrer le service ZombieForcaster version 1

      #endregion

      #region Insérez les références à l'ensemble des services ThirdParty ici Version Séparément


      #endregion

      #region Insérez les références à l'ensemble des services Thirdparty ici Version Groupés

      #endregion

      #region Injection des trois version du Middleware
     
      #endregion

      services.AddControllersWithViews().AddRazorRuntimeCompilation();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }
      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthorization();

      // Ajoutez la configuration du Middleware ICI
      

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}

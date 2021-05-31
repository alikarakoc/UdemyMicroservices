﻿using FreeCourse.IdentityServer.Data;
using FreeCourse.IdentityServer.Models;
using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FreeCourse.IdentityServer
{
   public class Startup
   {
      public IWebHostEnvironment Environment { get; }
      public IConfiguration Configuration { get; }

      public Startup(IWebHostEnvironment environment, IConfiguration configuration)
      {
         Environment = environment;
         Configuration = configuration;
      }

      public void ConfigureServices(IServiceCollection services)
      {

         services.AddLocalApiAuthentication();
         services.AddControllersWithViews();

         services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

         services.AddIdentity<ApplicationUser, IdentityRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders();

         var builder = services.AddIdentityServer(options =>
         {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;
            options.EmitStaticAudienceClaim = true;
         }).AddInMemoryIdentityResources(Config.IdentityResources)
         .AddInMemoryApiResources(Config.ApiResources)
             .AddInMemoryApiScopes(Config.ApiScopes)
             .AddInMemoryClients(Config.Clients)
             .AddAspNetIdentity<ApplicationUser>();
         builder.AddDeveloperSigningCredential();
         services.AddAuthentication()
             .AddGoogle(options =>
             {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                options.ClientId = "copy client ID from Google here";
                options.ClientSecret = "copy client secret from Google here";
             });
      }

      public void Configure(IApplicationBuilder app)
      {
         if (Environment.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
         }
         app.UseStaticFiles();
         app.UseRouting();
         app.UseIdentityServer();
         app.UseAuthentication();
         app.UseAuthorization();
         app.UseEndpoints(endpoints =>
         {
            endpoints.MapDefaultControllerRoute();
         });
      }
   }
}
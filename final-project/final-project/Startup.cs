using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Data.Implementation.SqlServer;
using final_project.Data.Interfaces;
using final_project.Service.Service;
using final_project.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using final_project.Domain.Model;
using final_project.Data.Context;

namespace final_project
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Add DbContext as a service
            services.AddDbContext<final_projectDbContext>();

            // Add Identity as a service
            services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<final_projectDbContext>();

            AddServiceImplementation(services);
            AddRepositoryImplementation(services);


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private void AddRepositoryImplementation(IServiceCollection services)
        {
            services.AddSingleton<IShelterRepository, SqlServerShelterRepository>();
            services.AddSingleton<IShelterTypeRepository, SqlServerShelterTypeRepository>();
        }

        private void AddServiceImplementation(IServiceCollection services)
        {
            services.AddSingleton<IShelterService, ShelterService>();
            services.AddSingleton<IShelterTypeService, ShelterTypeServices>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

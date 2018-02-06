using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PalicoForum.Data;
using PalicoForum.Models;
using PalicoForum.Services;

namespace PalicoForum
{
    public class Startup
    {
        /// <summary>
        /// Constructor, runs during Startup object initialization.
        /// </summary>
        /// <param name="configuration">Used to configure the app during setup.</param>
        public Startup(IConfiguration configuration)
        {
            // Saving passed in IConfiguration variable to read only class variable.
            Configuration = configuration;
        }

        // Read-only property initialized at object creation, used by ConfigureServices.
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container. Called before Configure. Is optional.
        /// </summary>
        /// <param name="services">IServiceCollection variable to use helper methods for adding/registering services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Needed for adding dependency injection to app. Allows use of MS SQL Server Database.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Used to enable login functionality to app, possible through dependency injection. Sets up storage of identity information. Adds token usage for changing account info or setting up 2FA.
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            // Enables MVC architecture as well as Razor pages.
            services.AddMvc();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline. Mandatory method.
        /// </summary>
        /// <param name="app">IApplicationBuilder variable to use helper methods for configuring an app's request pipeline</param>
        /// <param name="env">Used to check whether a development environment is in use.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Gives more verbose and detailed error pages 
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                // Uses pre-made error view for errors
                app.UseExceptionHandler("/Home/Error");
            }

            // Adds use of static files such as CSS.
            app.UseStaticFiles();

            // Adds authentication middleware to the pipeline.
            app.UseAuthentication();

            // Adds routing middleware to the request pipeline, and configures MVC as the default handler.
            app.UseMvc(routes =>
            {
                // Index.cshtml in the Home Controller is the home page.
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

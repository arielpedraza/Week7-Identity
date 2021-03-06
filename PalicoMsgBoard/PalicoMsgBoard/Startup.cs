﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PalicoMsgBoard.Data;
using PalicoMsgBoard.Models;
using PalicoMsgBoard.Services;
using PalicoMsgBoard.Models.Interfaces;

namespace PalicoMsgBoard
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
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IMessageService, MessageService>();

            services.AddMvc();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAccount", policy => policy.RequireRole("Palico", "Hunter").Build());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            
            var x = roleManager.RoleExistsAsync(AppRoles.Palico);
            x.Wait();
            if (!x.Result)
            {
                var a = roleManager.CreateAsync(new IdentityRole
                {
                    Name = AppRoles.Palico,
                    NormalizedName = AppRoles.Palico
                });
                a.Wait();

                a = roleManager.CreateAsync(new IdentityRole
                {
                    Name = AppRoles.Hunter,
                    NormalizedName = AppRoles.Hunter
                });
                a.Wait();
            }
        }
    }
}

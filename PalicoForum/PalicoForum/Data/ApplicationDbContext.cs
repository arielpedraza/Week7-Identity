using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PalicoForum.Models;

namespace PalicoForum.Data
{
    /// <summary>
    /// Class inherits from DbContext meant for Identity with type ApplicationUser. 
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Constructor for Application DbContext class. 
        /// </summary>
        /// <param name="options">Variable for utilizing helper methods available to DbContextOptions.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Example of Polymorphism. Can customize the model by overriding the defaults like changing table names.
        /// </summary>
        /// <param name="builder">Model Builder variable to call helper methods on.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PalicoForum.Models;

namespace PalicoForum.Controllers
{
    /// <summary>
    /// Home View will execute methods in this controller. Inherits from Controller class.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Call this method to return the Index page.
        /// </summary>
        /// <returns>Views/Home/Index.cshtml</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Call this method to return the About page.
        /// </summary>
        /// <returns>Views/Home/About.cshtml</returns>
        public IActionResult About()
        {
            // Accessible on the front end by using the key specified.
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Call this method to return the Contact page.
        /// </summary>
        /// <returns>Views/Home/Contact.cshtml</returns>
        public IActionResult Contact()
        {
            // Accessible on the front end by using the key specified.
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        // Can only assume this method will be called if the Home View folder calls something that doesn't exist.
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

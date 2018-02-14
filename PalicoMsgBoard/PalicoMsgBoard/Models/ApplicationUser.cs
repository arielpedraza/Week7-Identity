﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PalicoMsgBoard.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public int HuntersId { get; set; }
    }

    public static class AppRoles
    {
        public const string Palico = "Palico";
        public const string Hunter = "Hunter";
    }
}

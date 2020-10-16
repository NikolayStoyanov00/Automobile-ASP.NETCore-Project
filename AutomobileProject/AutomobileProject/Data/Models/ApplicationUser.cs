using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileProject.Data.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        public string Town { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace VkSearcher.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Year { get; set; } // place to add another properties of user
        public ApplicationUser()
        {

        }
    }
}
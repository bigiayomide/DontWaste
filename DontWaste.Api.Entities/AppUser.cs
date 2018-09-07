using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DontWaste.Api.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Orders = new List<Order>();
        }
        public List<Order> Orders { get; set; }
    }
}

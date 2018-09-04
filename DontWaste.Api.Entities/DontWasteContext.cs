using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DontWaste.Api.Entities
{
    public class DontWasteContext : IdentityDbContext<AppUser>
    {
        public DontWasteContext(DbContextOptions<DontWasteContext> options) : base(options)
        {
        }
        public DontWasteContext()
        {
        }
    }
}

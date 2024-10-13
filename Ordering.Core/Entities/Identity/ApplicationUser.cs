using System;
using Microsoft.AspNetCore.Identity;

namespace Ordering.Infrastructure.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        //public string? Email { get; set; }
        // public string? username { get; set; }
    }

}

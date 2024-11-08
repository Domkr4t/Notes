﻿using Microsoft.AspNetCore.Identity;

namespace Notes.Identity.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }
}

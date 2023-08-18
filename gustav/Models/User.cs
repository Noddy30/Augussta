using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;

namespace gustav.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        
    }
}


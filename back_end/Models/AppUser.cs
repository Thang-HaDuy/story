using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace App.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<Token> Tokens { get; set; }
    }
}
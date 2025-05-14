using Microsoft.AspNetCore.Identity;

using App.Areas.Action.Models;

namespace App.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<Token> Tokens { get; set; }
        public ICollection<Follow> Follows { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<View> Views { get; set; }


    }
}

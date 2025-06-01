using Microsoft.AspNetCore.Identity;

using App.Areas.Action.Models;

namespace App.Models
{
    public class AppUser : IdentityUser
    {
        public string? Avatar { get; set; }
        public ushort Gender { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<Token>? Tokens { get; set; }
        public ICollection<Follow>? Follows { get; set; }
        public ICollection<Rating>? Ratings { get; set; }
        public ICollection<View>? Views { get; set; }


    }
}

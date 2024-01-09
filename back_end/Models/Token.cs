using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class Token
    {
        [Key]
        public string TokenId { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
        public DateTime CreateAt  { get; set; }
        public DateTime ExpirationDate  { get; set; }
    }
}
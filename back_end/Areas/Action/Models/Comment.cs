using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using App.Models;
using App.Areas.Management.Models;


namespace App.Areas.Action.Models
{
    public class Comment
    {
        [Key]
        public string Id {set; get;} = Guid.NewGuid().ToString();
        public string UserId {set; get;}
        public string? ChapterId {set; get;}
        public string? ParentId {set; get;}

        public string content {set; get;}

        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        [ForeignKey("ChapterId")]
        public Chapter chapter { get; set; }

        [ForeignKey("ParentId")]
        public Comment Parent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public ICollection<Comment> Parents { get; set; }
        public ICollection<LikeComment> Like { get; set; }
    }
}
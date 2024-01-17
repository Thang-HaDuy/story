using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using App.Areas.Action.Models;

namespace App.Areas.Management.Models
{
    public class Chapter
    {
        [Key]
        public string? Id { get; set; }
        
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Phải nhập {0}")]
        public float Number { get; set; }
        
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Column(TypeName = "nvarchar(max)")]
        public string Content { get; set; }
        public string StoryId { get; set; }

        [ForeignKey("StoryId")]
        public Story Story { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public ICollection<LikeComment> LikeComments { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
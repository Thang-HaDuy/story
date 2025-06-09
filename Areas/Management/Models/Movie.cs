using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Areas.Action.Models;

namespace App.Areas.Management.Models
{
    public class Movie
    {
        [Key]
        public string? Id { get; set; }

        [Display(Name = "Tên Truyện")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string? Name { get; set; }

        [Display(Name = "Mô Tả")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Column(TypeName = "text")]
        public string? Description { get; set; }

        [Display(Name = "Tác Giả")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string? Author { get; set; }

        [Display(Name = "Ảnh Đại Diện")]
        public string? Avatar { get; set; }

        [Display(Name = "Ảnh Bìa")]
        public string? Background { get; set; }


        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "Trạng Thái")]
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


        [NotMapped]
        [Display(Name = "Chuyên mục")]
        public string[] CategoryIDs { get; set; } = [];
        public ICollection<CategoryMovie> CategoryMovie { get; set; } = [];
        public ICollection<Episode> Episodes { get; set; } = [];
        public ICollection<Follow> Follows { get; set; } = [];
        public ICollection<Rating> Ratings { get; set; } = [];
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Areas.Management.Models
{
    public class Category
    {
        [Key]
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<CategoryStory>? CategoryStory { get; set; }
    }
}
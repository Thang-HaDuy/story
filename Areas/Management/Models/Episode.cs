using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using App.Areas.Action.Models;

namespace App.Areas.Management.Models
{
    public class Episode
    {
        [Key]
        public string? Id { get; set; }

        [Required(ErrorMessage = "Phải nhập {0}")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Phải nhập {0}")]
        public float Number { get; set; }


        [Display(Name = "Video")]
        public string? FileName { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        // [FileExtensions(Extensions = "mp4")]
        [Display(Name = "Chọn file upload")]
        public IFormFile? FileUpload { get; set; }
        public string? MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}

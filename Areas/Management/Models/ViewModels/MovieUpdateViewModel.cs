using System.ComponentModel.DataAnnotations;
using App.Areas.Action.Models;
using App.Utilities;

namespace App.Areas.Management.Models.ViewModels
{
    public class MovieUpdateViewModel
    {
        [Key]
        public string? Id { get; set; }
        public string[]? CategoryIDs { get; set; } = [];

        [Display(Name = "Tên Truyện")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string? Name { get; set; }

        [Display(Name = "Mô Tả")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string? Description { get; set; }

        [Display(Name = "Tác Giả")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string? Author { get; set; }

        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".gif", ".pdf", ".webp" }, ErrorMessage = "Only jpg, png, gif, webp, and pdf files are allowed.")]
        [Display(Name = "Thêm Avatar")]
        public IFormFile? FileAvatar { get; set; }

        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".gif", ".pdf", ".webp" }, ErrorMessage = "Only jpg, png, gif, webp, and pdf files are allowed.")]
        [Display(Name = "Thêm Background")]
        public IFormFile? FileBackground { get; set; }

        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "Trạng Thái")]
        public string? Status { get; set; }
    }
}
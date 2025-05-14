using System.ComponentModel.DataAnnotations;
using App.Areas.Action.Models;

namespace App.Areas.Management.Models.ViewModels
{
    public class MovieViewModel
    {

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
        [FileExtensions(Extensions = ".png,.jpg,.jpeg,.gif")]
        [Display(Name = "Chọn file upload")]
        public IFormFile? FileAvatar { get; set; }

        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = ".png,.jpg,.jpeg,.gif")]
        [Display(Name = "Chọn file upload")]
        public IFormFile? FileBackground { get; set; }

        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "Trạng Thái")]
        public string? Status { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace App.Models.ViewModels
{
    public class ResetModel
    {
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "Code", Prompt = "Code")]
        public string? Code { get; set; }


        [Required(ErrorMessage = "Phải nhập {0}")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu", Prompt = "Mật khẩu")]
        public string? Password { get; set; }
    }
}
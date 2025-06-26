using System.ComponentModel.DataAnnotations;

public class ConfirmEmailModel
{
    [Required(ErrorMessage = "Phải nhập {0}")]
    [Display(Name = "Code", Prompt = "Code")]
    public string? Code { get; set; }
    [Required(ErrorMessage = "Phải nhập {0}")]
    [Display(Name = "Email", Prompt = "Email")]
    public string? Email { get; set; }
}
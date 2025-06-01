using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.ViewModels
{
    public class UpdateUserModel
    {
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        [Display(Name = "Chọn file upload")]
        public IFormFile? Avatar { get; set; }
        public ushort Gender { get; set; }
        public string? Password { get; set; }
    }
}
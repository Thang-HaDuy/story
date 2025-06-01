using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace App.Utilities
{
    public class AllowedExtensionsAttribute(string[] extensions) : ValidationAttribute
    {
        private readonly string[] _extensions = [.. extensions.Select(e => e.ToLower())];

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName).ToLower();
                if (!_extensions.Contains(extension))
                {
                    return new ValidationResult(ErrorMessage ?? $"These extensions are allowed only: {string.Join(", ", _extensions)}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
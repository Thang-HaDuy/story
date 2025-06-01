using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Utilities
{
    public class UploadImage
    {
        public static async Task<string> UploadImageAsync(string TypeParent, string FolderParent, IFormFile FileUpload)
        {
            var year = DateTime.Now.Year.ToString();
            var month = DateTime.Now.Month.ToString();
            var day = DateTime.Now.Day.ToString();

            var nameFile = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(FileUpload.FileName);

            var pathFile = Path.Combine("Uploads", TypeParent, FolderParent, year, month, day);
            var linkFile = Path.Combine(pathFile, nameFile);
            var folderPath = Path.Combine("wwwroot", pathFile);
            var file = Path.Combine(folderPath, nameFile);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (var filestream = new FileStream(file, FileMode.Create))
            {
                await FileUpload.CopyToAsync(filestream);
            }

            return linkFile;
        }
    }
}
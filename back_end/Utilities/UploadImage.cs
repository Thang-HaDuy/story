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
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();

            string nameFile = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(FileUpload.FileName);

            string pathFile = Path.Combine("Uploads", TypeParent, FolderParent, year, month, day);
            string linkFile = Path.Combine(pathFile, nameFile);
            string folderPath = Path.Combine("wwwroot", pathFile);
            string file = Path.Combine(folderPath, nameFile);

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
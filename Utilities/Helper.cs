using System.Diagnostics;
using FFMpegCore;
using FFMpegCore.Enums;
using FFMpegCore.Pipes;

namespace App.Utilities
{
    public class Helper
    {
        public record UploadVideoResult(string? FileStream, string? OriginalFile);
        public static bool IsValidFrontendUrl(IConfiguration configuration, string clientUrl)
        {
            var frontendUrls = configuration.GetSection("HostClient:frontend").Get<string[]>();

            // Kiểm tra nếu clientUrl có trong danh sách frontendUrls
            return frontendUrls != null && frontendUrls.Contains(clientUrl);
        }

        public static async Task<UploadVideoResult> UploadVideo(string TypeParent, string FolderParent, IFormFile FileUpload, IWebHostEnvironment Hostenvironment)
        {
            try
            {
                var year = DateTime.Now.Year.ToString();
                var month = DateTime.Now.Month.ToString();
                var day = DateTime.Now.Day.ToString();

                var nameFile = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(FileUpload.FileName);

                var pathFile = Path.Combine("Uploads", TypeParent, FolderParent, year, month, day);
                var folderPath = Path.Combine(Hostenvironment.WebRootPath, pathFile);
                var file = Path.Combine(folderPath, nameFile);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                using (var filestream = new FileStream(file, FileMode.Create))
                {
                    await FileUpload.CopyToAsync(filestream);
                }

                // Tạo HLS playlist
                var hlsFileName = Guid.NewGuid().ToString();
                var pathhlsfordel = Path.Combine("Streaming", year, month);
                var hlsPath = Path.Combine(Hostenvironment.WebRootPath, pathhlsfordel);
                var linkHls = Path.Combine(pathhlsfordel, (hlsFileName + ".m3u8"));
                var hlsFile = Path.Combine(hlsPath, hlsFileName);

                if (!Directory.Exists(hlsPath))
                {
                    Directory.CreateDirectory(hlsPath);
                }

                var arguments = $"-i \"{file}\" -c:v libx264 -b:v 1M -hls_time 10 -hls_list_size 0 -hls_segment_filename \"{hlsFile}%03d.ts\" \"{hlsFile}.m3u8\"";

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "ffmpeg",
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };

                process.Start();
                process.WaitForExit();

                return new UploadVideoResult(linkHls, pathFile + "/" + nameFile);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(">>> Check update: " + e);
                return new UploadVideoResult("", ""); ;
            }

        }
    }
}
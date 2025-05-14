namespace App.Utilities
{
    public class Helper
    {
        public static bool IsValidFrontendUrl(IConfiguration configuration, string clientUrl)
        {
            var frontendUrls = configuration.GetSection("HostClient:frontend").Get<string[]>();

            // Kiểm tra nếu clientUrl có trong danh sách frontendUrls
            return frontendUrls != null && frontendUrls.Contains(clientUrl);
        }
    }
}
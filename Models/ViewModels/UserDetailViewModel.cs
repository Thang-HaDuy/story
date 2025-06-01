namespace App.Models.ViewModels
{
    public class UserDetailViewModel
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Avatar { get; set; }
        public ushort Gender { get; set; }
        public string? CreatedAt { get; set; }
    }
}
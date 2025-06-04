
namespace App.Areas.Management.Models.ViewModels
{
    class MovieTopRatingExtendViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? Background { get; set; }
        public float? TotalRate { get; set; }
        public float? TotalEpisode { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}

using App.Areas.Management.ApiModels;

namespace App.Areas.Management.Models.ViewModels
{
    class MovieTopRatingExtendViewModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? Background { get; set; }
        public string? Categories { get; set; }
        public InfoResponse? Info { get; set; }
    }
}
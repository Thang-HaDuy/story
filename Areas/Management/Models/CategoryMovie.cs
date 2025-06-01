using System.ComponentModel.DataAnnotations.Schema;

namespace App.Areas.Management.Models
{
    public class CategoryMovie
    {
        public string? CategoryId { get; set; }
        public string? MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = new Category();

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; } = new Movie();

    }
}
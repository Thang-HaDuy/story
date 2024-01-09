using System.ComponentModel.DataAnnotations.Schema;

namespace App.Areas.Management.Models
{
    public class CategoryStory
    {
        public string CategoryId { get; set; }
        public string StoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("StoryId")]
        public Story Story { get; set; }

    }
}
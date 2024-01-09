using System.ComponentModel.DataAnnotations.Schema;

using App.Models;
using App.Areas.Management.Models;

namespace App.Areas.Action.Models
{
    public class Follow
    {
        public string UserId {set; get;}
        public string StoryId {set; get;}

        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        [ForeignKey("StoryId")]
        public Story Story { get; set; }
        
    }
}
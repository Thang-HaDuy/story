using System.ComponentModel.DataAnnotations.Schema;

using App.Models;

namespace App.Areas.Action.Models
{
    public class LikeComment
    {
        public string UserId {set; get;}
        public string CommentId {set; get;}

        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        [ForeignKey("CommentId")]
        public Comment Comment { get; set; }
    }
}
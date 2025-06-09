using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using App.Areas.Management.Models;
using App.Models;

namespace App.Areas.Action.Models
{
    public class View
    {
        public string Id { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string EpisodeId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        [ForeignKey("EpisodeId")]
        public Episode Episode { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}

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
        public string UserId { get; set; }
        public string MovieId { get; set; }

        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using App.Areas.Action.Models;

namespace App.Areas.Management.Dtos
{
    public class MovieSearchDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Avatar { get; set; }
        public int CountEpisodes { get; set; }
        public int? CountViews { get; set; }
        public int? Vote { get; set; }
    }
}

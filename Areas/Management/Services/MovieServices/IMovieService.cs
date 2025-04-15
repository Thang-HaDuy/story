using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models.ViewModels;

namespace App.Areas.Management.Services.MovieServices
{
    public interface IMovieService
    {
        public Task<ApiResponse> SearchAsync(string query, string? type, int? page, int? pagesite);
    }
}

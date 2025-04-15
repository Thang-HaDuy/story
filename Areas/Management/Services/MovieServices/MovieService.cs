using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Areas.Management.Dtos;
using App.Areas.Management.Models;
using App.Data;
using App.Models.ViewModels;
using App.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace App.Areas.Management.Services.MovieServices
{
    public class MovieService : IMovieService
    {
        private readonly DataDbContext _context;
        private readonly IConfiguration _configuration;

        public MovieService
        (
            IConfiguration configuration,
            DataDbContext context
        )
        {
            _configuration = configuration;
            _context = context;
        }
        public async Task<ApiResponse> SearchAsync(string query, string? type, int? page, int? pagelimit)
        {
            IPagedList<MovieSearchDto> movies;
            if (type == "full")
            {
                var pageNumber = page ?? 1;
                var pageSize = pagelimit ?? 30;

                movies = await _context.movies
                                    .Where(m => m.Name.Contains(query))
                                    .Include(m => m.Episodes)
                                    .Include(m => m.Ratings)
                                    .Include(m => m.views)
                                    .Select(m => new MovieSearchDto()
                                    {
                                        Id = m.Id,
                                        Name = m.Name,
                                        CountEpisodes = m.Episodes.Count(),
                                        FileName = m.FileName,
                                        CountViews = m.views.Count(),
                                        vote = m.Ratings.Count(),
                                    })
                                    .ToPagedListAsync(pageNumber, pageSize);
            }
            else
            {
                movies = await _context.movies
                                    .Where(m => m.Name.Contains(query))
                                    .Include(m => m.Episodes)
                                    .Select(m => new MovieSearchDto()
                                    {
                                        Id = m.Id,
                                        Name = m.Name,
                                        CountEpisodes = m.Episodes.Count(),
                                        FileName = m.FileName,
                                    })
                                    .ToPagedListAsync(1, 5);
            }


            if (movies == null || !movies.Any())
            {
                return new ApiResponse()
                {
                    Error = true,
                    Message = "No data matching",
                    Success = false,
                    Data = null
                };
            }

            return new ApiResponse()
            {
                Error = false,
                Message = "Success",
                Success = true,
                Data = Paginated.RenderObject(movies)
            };
        }
    }
}

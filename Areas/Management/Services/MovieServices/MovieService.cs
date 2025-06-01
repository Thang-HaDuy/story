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
    public class MovieService(
        IConfiguration configuration,
        DataDbContext context
        ) : IMovieService
    {
        private readonly DataDbContext _context = context;
        private readonly IConfiguration _configuration = configuration;

        public async Task<ApiResponse> SearchAsync(string query, string? type, int? page, int? pagelimit)
        {
            IPagedList<MovieSearchDto> movies;
            if (type == "full")
            {
                var pageNumber = page ?? 1;
                var pageSize = pagelimit ?? 30;

                movies = await _context.Movies
                                    .Where(m => m.Name!.Contains(query))
                                    .Include(m => m.Episodes)
                                    .Include(m => m.Ratings)
                                    .Include(m => m.Views)
                                    .Select(m => new MovieSearchDto()
                                    {
                                        Id = m.Id,
                                        Name = m.Name,
                                        CountEpisodes = m.Episodes!.Count(),
                                        Avatar = m.Avatar,
                                        CountViews = m.Views!.Count(),
                                        vote = m.Ratings!.Count(),
                                    })
                                    .ToPagedListAsync(pageNumber, pageSize);
            }
            else
            {
                movies = await _context.Movies
                                    .Where(m => m.Name!.Contains(query))
                                    .Include(m => m.Episodes)
                                    .Select(m => new MovieSearchDto()
                                    {
                                        Id = m.Id,
                                        Name = m.Name,
                                        CountEpisodes = m.Episodes!.Count(),
                                        Avatar = m.Avatar,
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


        public async Task<ApiResponse> MovieTopRatingAsync()
        {
            var result = new ApiResponse()
            {
                Error = true,
                Message = "No data matching",
                Success = false,
                Data = null
            };

            var top10Movies = await _context.Movies
                .Where(m => m.Ratings.Any())
                .OrderByDescending(m => m.Ratings.Average(r => r.Rate) * Math.Log(m.Ratings.Count() + 1))
                .Select(m => new
                {
                    averageRating = m.Ratings.Average(r => r.Rate),
                    name = m.Name,
                    avatar = m.Avatar,
                    totalEpisode = m.Episodes.Count()
                })
                .Take(10)
                .ToListAsync();

            result.Data = top10Movies;
            return result;
        }
    }
}

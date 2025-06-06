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
using App.Areas.Management.Models.ViewModels;
using App.Areas.Management.ApiModels;
using Humanizer;

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
                                        Vote = m.Ratings!.Count(),
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
                Error = false,
                Message = "",
                Success = true,
                Data = null
            };

            var top10Movies = await _context.Movies
                .Where(m => m.Ratings.Any())
                .OrderByDescending(m => m.Ratings.Average(r => r.Rate) * Math.Log(m.Ratings.Count() + 1))
                .Take(10)
                .Select(m => new MovieTopRatingViewModel()
                {
                    Id = m.Id,
                    AverageRating = m.Ratings.Average(r => r.Rate),
                    Name = m.Name,
                    Avatar = m.Avatar,
                    Episode = m.Episodes.Count(),
                    Description = m.Description,
                    ClassName = $"hoverEffect{m.Id}"
                })
                .ToListAsync();

            result.Data = top10Movies;
            return result;
        }

        public async Task<ApiResponse> SlideAnimeTopAsync()
        {
            var result = new ApiResponse()
            {
                Error = false,
                Message = "",
                Success = true,
                Data = null
            };

            var top10Movies = await _context.Movies
                .Include(m => m.Ratings)
                .Include(m => m.Episodes)
                .Where(m => m.Ratings.Any())
                .OrderByDescending(m => m.Ratings.Average(r => r.Rate) * Math.Log(m.Ratings.Count() + 1))
                .Take(10)
                .Select(m => new MovieTopRatingExtendViewModel()
                {
                    Id = m.Id,
                    Name = m.Name,
                    Background = m.Background,
                    Author = m.Author,
                    Description = m.Description,
                    Categories = string.Join(", ", _context.CategoryMovie
                                        .Include(m => m.Category)
                                        .Where(c => c.MovieId == m.Id)
                                        .Select(m => m.Category.Name)
                                        .ToList()),

                    Info = new InfoResponse
                    (
                        m.Ratings.Sum(r => r.Rate),
                        m.CreatedAt.ToString(),
                        "HD",
                        m.Episodes.Count()
                    )
                })
                .ToListAsync();

            result.Data = top10Movies;
            return result;
        }

        public async Task<ApiResponse> NewAnimeUpdateAsync()
        {
            var result = new ApiResponse()
            {
                Error = false,
                Message = "",
                Success = true,
                Data = null
            };
            var top10Movies = await _context.Movies
                .Include(m => m.Ratings)
                .Include(m => m.Episodes)
                .Where(m => m.Ratings.Any())
                .OrderByDescending(m => m.Ratings.Average(r => r.Rate) * Math.Log(m.Ratings.Count() + 1))
                .Take(10)
                .Select(m => new MovieResponse(
                    m.Avatar,
                    _context.Views.Where(v => v.MovieId == m.Id).Count(),
                    new ItemHoverResponse(
                        m.Name,
                        m.Description,
                        m.Author,
                        string.Join(", ",
                         _context.CategoryMovie
                            .Include(m => m.Category)
                            .Where(c => c.MovieId == m.Id)
                            .Select(m => m.Category.Name)
                            .ToList()),
                        "Đang cập nhật",
                        new InfoResponse(
                            m.Ratings.Sum(r => r.Rate),
                            m.CreatedAt.ToString(),
                            "HD",
                            m.Episodes.Count()
                        )
                    )
                ))
                .ToListAsync();

            result.Data = top10Movies;
            return result;
        }
    }
}

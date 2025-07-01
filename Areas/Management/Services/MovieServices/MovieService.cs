using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Areas.Management.Models;
using App.Data;
using App.Models.ViewModels;
using App.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using App.Areas.Management.Models.ViewModels;
using App.Areas.Management.ApiModels;
using Humanizer;
using Org.BouncyCastle.Crypto.Engines;

namespace App.Areas.Management.Services.MovieServices
{
    public class MovieService(
        DataDbContext context
        ) : IMovieService
    {
        private readonly DataDbContext _context = context;

        public async Task<ApiResponse> SearchAsync(string query, string? type, int? page, int? pagelimit)
        {
            IPagedList<MovieSearchResponse> movies;
            if (type == "extend")
            {
                var pageNumber = page ?? 1;
                var pageSize = pagelimit ?? 30;

                movies = await _context.Movies
                                    .Where(m => m.Name!.Contains(query))
                                    .Include(m => m.Episodes)
                                    .Include(m => m.Ratings)
                                    .Select(m => new MovieSearchResponse(
                                        m.Id,
                                        m.Name,
                                        m.Avatar,
                                        m.Episodes!.Count(),
                                        _context.Movies
                                            .Where(mm => mm.Id == m.Id)
                                            .SelectMany(mm => mm.Episodes)
                                            .SelectMany(e => e.Views)
                                            .Count(),
                                            m.Ratings.Average(r => r.Rate)
                                    ))
                                    .ToPagedListAsync(pageNumber, pageSize);
            }
            else
            {
                movies = await _context.Movies
                                    .Where(m => m.Name!.Contains(query))
                                    .Include(m => m.Episodes)
                                    .Select(m => new MovieSearchResponse(
                                        m.Id,
                                        m.Name,
                                        m.Avatar,
                                        m.Episodes!.Count(),
                                        0,
                                        0
                                    ))
                                    .ToPagedListAsync(1, 5);
            }


            return new ApiResponse()
            {
                Error = false,
                Message = "Success",
                Success = true,
                Data = type == "extend" ? Paginated.RenderObject(movies) : movies
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

            var movie = await _context.Movies
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

            result.Data = movie;
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

            var movie = await _context.Movies
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

            result.Data = movie;
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
            var movie = await _context.Movies
                .Include(m => m.Ratings)
                .Include(m => m.Episodes)
                .Where(m => m.Episodes.Any())
                .Select(m => new
                {
                    Movie = m,
                    LatestEpisodeCreatedAt = _context.Episodes
                        .Where(e => e.MovieId == m.Id)
                        .Max(e => (DateTime?)e.CreatedAt)
                })
                .OrderByDescending(x => x.LatestEpisodeCreatedAt)
                .Take(10)
                .Select(m => new MovieResponse(
                    m.Movie.Avatar,
                    _context.Views.Where(v => v.Episode.MovieId == m.Movie.Id).Count(),
                    new ItemHoverResponse(
                        m.Movie.Id,
                        m.Movie.Name,
                        m.Movie.Description,
                        m.Movie.Author,
                        string.Join(", ",
                         _context.CategoryMovie
                            .Include(c => c.Category)
                            .Where(c => c.MovieId == m.Movie.Id)
                            .Select(c => c.Category.Name)
                            .ToList()),
                        "Đang cập nhật",
                        new InfoResponse(
                            m.Movie.Ratings.Sum(r => r.Rate),
                            m.Movie.CreatedAt.ToString(),
                            "HD",
                            m.Movie.Episodes.Count()
                        )
                    )
                ))
                .ToListAsync();

            result.Data = movie;
            return result;
        }

        public async Task<ApiResponse> UpcommingAnimeAsync()
        {
            var result = new ApiResponse()
            {
                Error = false,
                Message = "",
                Success = true,
                Data = null
            };
            var movie = await _context.Movies
                .Include(m => m.Ratings)
                .Include(m => m.Episodes)
                .Where(m => m.Episodes.Count() == 0)
                .OrderByDescending(m => m.CreatedAt)
                .Take(10)
                .Select(m => new MovieResponse(
                    m.Avatar,
                    _context.Views.Where(v => v.Episode.MovieId == m.Id).Count(),
                    new ItemHoverResponse(
                        m.Id,
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

            result.Data = movie;
            return result;
        }

        public async Task<ApiResponse> NominatedAnimeAsync(string filter)
        {
            DateTime startTime, endTime;
            var now = DateTime.UtcNow; // Hoặc DateTime.Now nếu dùng giờ địa phương

            var result = new ApiResponse()
            {
                Error = false,
                Message = "",
                Success = true,
                Data = null
            };


            if (filter == "most_viewed_month")
            {
                // Lấy từ đầu tháng đến cuối tháng hiện tại
                startTime = new DateTime(now.Year, now.Month, 1);
                endTime = startTime.AddMonths(1).AddTicks(-1); // Cuối tháng
            }
            else if (filter == "most_viewed_week")
            {
                // Lấy từ thứ Hai đến Chủ Nhật của tuần hiện tại
                var daysToMonday = ((int)now.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
                startTime = now.Date.AddDays(-daysToMonday); // Thứ Hai
                endTime = startTime.AddDays(6).AddHours(23).AddMinutes(59); // Chủ Nhật
            }
            else // most_viewed_day
            {
                // Lấy trong ngày hiện tại
                startTime = now.Date; // 00:00:00 của hôm nay
                endTime = startTime.AddHours(23).AddMinutes(59); // 23:59:59 của hôm nay
            }

            var movies = await context.Movies
                .Where(m => m.Episodes.Any())
                .Select(m => new
                {
                    Movie = m,
                    ViewCount = m.Episodes
                        .SelectMany(e => e.Views)
                        .Count(v => v.CreatedAt >= startTime && v.CreatedAt <= endTime)
                })
                .OrderByDescending(x => x.ViewCount)
                .Take(10)
                .Select(x => new MovieResponse(
                    x.Movie.Avatar,
                    _context.Views.Where(v => v.Episode.MovieId == x.Movie.Id).Count(),
                    new ItemHoverResponse(
                        x.Movie.Id,
                        x.Movie.Name,
                        x.Movie.Description,
                        x.Movie.Author,
                        string.Join(", ",
                         _context.CategoryMovie
                            .Include(m => m.Category)
                            .Where(c => c.MovieId == x.Movie.Id)
                            .Select(m => m.Category.Name)
                            .ToList()),
                        "Đang cập nhật",
                        new InfoResponse(
                            x.Movie.Ratings.Sum(r => r.Rate),
                            x.Movie.CreatedAt.ToString(),
                            "HD",
                            x.Movie.Episodes.Count()
                        )
                    )
                ))
                .ToListAsync();


            result.Data = movies;
            return result;
        }

        public async Task<ApiResponse> MinimalAnimeUpdatesAsync()
        {

            var result = new ApiResponse()
            {
                Error = false,
                Message = "",
                Success = true,
                Data = null
            };
            var movie = await _context.Movies
                .Include(m => m.Ratings)
                .Include(m => m.Episodes)
                .Where(m => m.Episodes.Any())
                .Select(m => new
                {
                    Movie = m,
                    LatestEpisodeCreatedAt = _context.Episodes
                        .Where(e => e.MovieId == m.Id)
                        .Max(e => (DateTime?)e.CreatedAt)
                })
                .OrderByDescending(x => x.LatestEpisodeCreatedAt)
                .Take(10)
                .Select(m => new MinimalMovieResponse(
                    m.Movie.Id,
                    m.Movie.Name,
                    m.Movie.Episodes.Count()
                ))
                .ToListAsync();

            result.Data = movie;
            return result;
        }

        public async Task<ApiResponse> GetMovieBanerByIdAsync(string id)
        {

            var result = new ApiResponse()
            {
                Error = false,
                Message = "",
                Success = true,
                Data = null
            };
            var movie = await _context.Movies
                .Include(m => m.Ratings)
                .Include(m => m.Episodes)
                .Where(m => m.Id == id)
                .Select(m => new GetMovieBanerByIdResponse(
                    m.Id,
                    m.Name,
                    m.Background,
                    m.Avatar,
                    m.Description,
                    m.Episodes.Count(),
                    m.CreatedAt.ToString(),
                    _context.Views.Where(v => v.Episode.MovieId == m.Id).Count(),
                    m.Ratings.Count(),
                    m.Ratings.Average(r => r.Rate),
                    string.Join(", ", _context.Episodes.Where(e => e.MovieId == m.Id).OrderBy(m => m.CreatedAt).Take(1).Select(e => e.Id).ToList())
                ))
                .ToListAsync();

            result.Data = movie;
            return result;
        }

        public async Task<ApiResponse> GetMovieInfoByIdAsync(string id)
        {
            var result = new ApiResponse()
            {
                Error = false,
                Message = "",
                Success = true,
                Data = null
            };
            var movie = await _context.Movies
                .Include(m => m.Ratings)
                .Include(m => m.Episodes)
                .Where(m => m.Id == id)
                .Select(m => new GetMovieInfoByIdResponse(
                    m.Id,
                    string.Join(", ", _context.Episodes.Where(e => e.MovieId == m.Id).OrderByDescending(m => m.CreatedAt).Take(3).Select(e => e.Number).ToList()),
                    m.Status,
                    string.Join(", ", _context.CategoryMovie
                            .Include(m => m.Category)
                            .Where(c => c.MovieId == m.Id)
                            .Select(m => m.Category.Name)
                            .ToList()),
                    m.Author,
                    m.Episodes.Count(),
                    "FHD",
                    m.Ratings.Average(r => r.Rate),
                    "VietSub"
                ))
                .ToListAsync();

            result.Data = movie;
            return result;
        }


        public async Task<ApiResponse> GetMovieSuggestAsync(string id)
        {
            var result = new ApiResponse()
            {
                Error = false,
                Message = "",
                Success = true,
                Data = null
            };
            // Lấy danh sách CategoryId của movieId
            var categoryIds = await _context.CategoryMovie
                .Where(cm => cm.MovieId == id)
                .Select(cm => cm.CategoryId)
                .ToListAsync();

            // Tìm các Movie khác có ít nhất một CategoryId trùng khớp
            var similarMovies = await _context.CategoryMovie
                .Where(cm => categoryIds.Contains(cm.CategoryId) && cm.MovieId != id)
                .Include(cm => cm.Movie)
                .Select(cm => new GetMovieSuggestResponse
                (
                    cm.Movie.Id,
                    cm.Movie.Name,
                    cm.Movie.Avatar,
                    _context.Ratings.Where(r => r.MovieId == cm.MovieId).Average(r => r.Rate),
                    _context.Episodes.Where(e => e.MovieId == cm.MovieId).Count()
                ))
                .Distinct() // Loại bỏ trùng lặp
                .Take(10)
                .ToListAsync();

            result.Data = similarMovies;
            return result;
        }


        public async Task<ApiResponse> GetMovieInLibraryAsync(string filter, int? page, int? pagesite)
        {
            var result = new ApiResponse()
            {
                Error = false,
                Message = "",
                Success = true,
                Data = null
            };

            IPagedList<GetMovieInLibraryRespone> movies;

            var pageNumber = page ?? 1;
            var pageSize = pagesite ?? 30;

            if (filter == "0-9")
            {
                movies = await _context.Movies
                .Where(m => !string.IsNullOrEmpty(m.Name) && EF.Functions.Like(m.Name, "[0-9]%"))
                .Select(m => new GetMovieInLibraryRespone(
                    m.Id,
                    m.Name,
                    m.Avatar,
                    m.CreatedAt.ToString(),
                    m.Status,
                    string.Join(", ", _context.CategoryMovie
                            .Include(m => m.Category)
                            .Where(c => c.MovieId == m.Id)
                            .Select(m => m.Category.Name)
                            .ToList()),
                    _context.Ratings.Where(r => r.MovieId == m.Id).Average(r => r.Rate)
                ))
                .ToPagedListAsync(pageNumber, pageSize);
            }
            else
            {
                movies = await _context.Movies
                    .Where(m => !string.IsNullOrEmpty(m.Name) && m.Name.ToLower().StartsWith(filter))
                    .Select(m => new GetMovieInLibraryRespone(
                        m.Id,
                        m.Name,
                        m.Avatar,
                        m.CreatedAt.ToString(),
                        m.Status,
                        string.Join(", ", _context.CategoryMovie
                                .Include(m => m.Category)
                                .Where(c => c.MovieId == m.Id)
                                .Select(m => m.Category.Name)
                                .ToList()),
                        _context.Ratings.Where(r => r.MovieId == m.Id).Average(r => r.Rate)
                    ))
                    .ToPagedListAsync(pageNumber, pageSize);
            }
            result.Data = Paginated.RenderObject(movies);
            return result;
        }
        public async Task<ApiResponse> GetEpisodeListAsync(string id)
        {
            var result = new ApiResponse()
            {
                Error = false,
                Message = "",
                Success = true,
                Data = null
            };
            var movie = await _context.Episodes
                .Where(m => m.MovieId == id)
                .OrderByDescending(m => m.CreatedAt)
                .Select(m => new GetEpisodeListRespone(
                    m.Id,
                    m.Number
                ))
                .ToListAsync();

            result.Data = movie;
            return result;
        }
    }
}

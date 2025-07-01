using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Areas.Management.Services.MovieServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace App.Areas.Management.Controllers.Apis
{
    [ApiController]
    [Route("Api/[controller]")]
    public class MovieApiController(IMovieService MovieService) : ControllerBase
    {
        private readonly IMovieService _movieService = MovieService;

        [HttpGet("search")]
        public async Task<IActionResult> SearchAsync(string query, string? type, int? page, int? pagesite)
        {
            var result = await _movieService.SearchAsync(query, type, page, pagesite);

            return result.Success ? Ok(result.Data) : NotFound();
        }

        [HttpGet("MovieTopRating")]
        public async Task<IActionResult> MovieTopRating()
        {
            var result = await _movieService.MovieTopRatingAsync();

            return result.Success ? Ok(result) : NotFound();
        }



        [HttpGet("SlideAnimeTop")]
        public async Task<IActionResult> SlideAnimeTop()
        {
            var result = await _movieService.SlideAnimeTopAsync();

            return result.Success ? Ok(result) : NotFound();
        }



        [HttpGet("NewAnimeUpdate")]
        public async Task<IActionResult> NewAnimeUpdate()
        {
            var result = await _movieService.NewAnimeUpdateAsync();

            return result.Success ? Ok(result) : NotFound();
        }

        [HttpGet("MinimalNewAnimeUpdates")]
        public async Task<IActionResult> MinimalAnimeUpdates()
        {
            var result = await _movieService.MinimalAnimeUpdatesAsync();
            return result.Success ? Ok(result) : NotFound();
        }

        [HttpGet("UpcommingAnime")]
        public async Task<IActionResult> UpcommingAnime()
        {
            var result = await _movieService.UpcommingAnimeAsync();

            return result.Success ? Ok(result) : NotFound();
        }


        [HttpGet("NominatedAnime")]
        public async Task<IActionResult> NominatedAnime(string filter)
        {
            var result = await _movieService.NominatedAnimeAsync(filter);

            return result.Success ? Ok(result) : NotFound();
        }


        [HttpGet("MovieInLibrary")]
        public async Task<IActionResult> MovieInLibrary(string filter, int? page, int? pagesite)
        {
            var result = await _movieService.GetMovieInLibraryAsync(filter, page, pagesite);

            return result.Success ? Ok(result.Data) : NotFound();
        }

        [HttpGet("MovieBanerById")]
        public async Task<IActionResult> MovieBanerById(string id)
        {
            var result = await _movieService.GetMovieBanerByIdAsync(id);

            return result.Success ? Ok(result) : NotFound();
        }

        [HttpGet("MovieInfoById")]
        public async Task<IActionResult> MovieInfoById(string id)
        {
            var result = await _movieService.GetMovieInfoByIdAsync(id);

            return result.Success ? Ok(result) : NotFound();
        }

        [HttpGet("MovieSuggest")]
        public async Task<IActionResult> MovieSuggest(string id)
        {
            var result = await _movieService.GetMovieSuggestAsync(id);

            return result.Success ? Ok(result) : NotFound();
        }

        [HttpGet("EpisodeList")]
        public async Task<IActionResult> EpisodeList(string id)
        {
            var result = await _movieService.GetEpisodeListAsync(id);

            return result.Success ? Ok(result) : NotFound();
        }
    }
}

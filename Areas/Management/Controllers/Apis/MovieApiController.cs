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
    [Route("api/[controller]")]
    public class MovieApiController(IMovieService MovieService) : ControllerBase
    {
        private readonly IMovieService _movieService = MovieService;

        [HttpGet("search")]
        public async Task<IActionResult> SearchAsync(string query, string? type, int? page, int? pagesite)
        {
            var result = await _movieService.SearchAsync(query, type, page, pagesite);

            if (result.Success != true) return NotFound();

            if (result.Data == null) return NoContent();

            return Ok(result.Data);
        }

        [HttpGet("MovieTopRating")]
        public async Task<IActionResult> MovieTopRating()
        {
            var result = await _movieService.MovieTopRatingAsync();

            return result.Success ? Ok(result) : NotFound();
        }



        [HttpGet("MovieTopRatingExtend")]
        public async Task<IActionResult> MovieTopRatingExtend()
        {
            var result = await _movieService.MovieTopRatingExtendAsync();

            return result.Success ? Ok(result) : NotFound();
        }


    }
}

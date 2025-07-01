using App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Areas.Management.Controllers.Apis
{
    [ApiController]
    [Route("Api/[controller]")]
    public class EpisodeApiController(DataDbContext context, IWebHostEnvironment hostenvironment) : ControllerBase
    {
        private readonly DataDbContext _context = context;

        [HttpGet("GetVideoOfEpisode")]
        public async Task<IActionResult> MovieInLibrary(string id)
        {
            if (id != null)
            {
                var result = await _context.Episodes.Where(e => e.Id == id).Select(e => new { VideoStream = e.FileStreaming }).ToListAsync();
                return Ok(result);
            }

            return NotFound();
        }
    }
}
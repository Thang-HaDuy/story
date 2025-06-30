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
        private readonly IWebHostEnvironment _hostenvironment = hostenvironment;
    }
}
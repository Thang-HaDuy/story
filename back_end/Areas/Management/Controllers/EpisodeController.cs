using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Areas.Management.Models;
using App.Data;
using X.PagedList;
using Microsoft.Extensions.Hosting;
using App.Utilities;

namespace back_end.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("[controller]/[action]")]
    public class EpisodeController : Controller
    {
        private readonly DataDbContext _context;

        public EpisodeController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Management/Episode
        public async Task<IActionResult> Index(string id, int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 10;

            var result = await _context.episodes.Include(e => e.Movie).Where(e => e.Movie.Id == id).ToPagedListAsync(pageNumber, pageSize);
            
            ViewBag.episodeIndex = (pageNumber - 1) * pageSize;
            ViewBag.id = id;
            return View(result);
        }

        // GET: Management/Episode/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var episode = await _context.episodes
                .Include(e => e.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (episode == null)
            {
                return NotFound();
            }

            ViewBag.id = episode.MovieId;
            return View(episode);
        }

        // GET: Management/Episode/Create
        public IActionResult Create(string id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: Management/Episode/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string id, [Bind("Name,Number,FileUpload")] Episode model)
        {
            if (id == null) return NotFound();

            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid().ToString();
                model.MovieId = id;
                model.CreatedAt = DateTime.UtcNow;
                model.UpdatedAt = DateTime.UtcNow;
                if (model.FileUpload != null && model.FileUpload.Length > 0) model.FileName = await UploadImage.UploadImageAsync("Video", "Episode", model.FileUpload);


                _context.Add(model);

                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id });
            }

            ViewBag.id = id;
            return View(model);
        }

        // GET: Management/Episode/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var episode = await _context.episodes.Include(e => e.Movie)
                    .FirstOrDefaultAsync(m => m.Id == id);;
            if (episode == null)
            {
                return NotFound();
            }

            ViewBag.parentId = episode.MovieId;
            return View(episode);
        }

        // POST: Management/Episode/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Number,FileUpload")] Episode model)
        {
            if (id == null) return NotFound();

            var episode = await _context.episodes.Include(e => e.Movie).FirstOrDefaultAsync(e => e.Id == id);

            if (episode == null) return NotFound();

            if (ModelState.IsValid)
            {
                if (model.FileUpload != null && model.FileUpload.Length > 0) episode.FileName = await UploadImage.UploadImageAsync("Video", "episode", model.FileUpload);
                episode.Name = model.Name;
                episode.Number = model.Number;

                _context.Update(episode);
                await _context.SaveChangesAsync();
            
                return RedirectToAction("Index", new { id = episode.MovieId });
            }

            ViewBag.parentId = episode.MovieId;
            return View(model);
        }

      // GET: Story/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var episode = await _context.episodes.Include(e => e.Movie).FirstOrDefaultAsync(c => c.Id == id);
            if (episode != null)
            {
                episode.DeletedAt = DateTime.UtcNow;
                _context.Update(episode);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", new { id = episode.MovieId });
        }

        // GET: Story/Delete/5
        public async Task<IActionResult> Restore(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var episode = await _context.episodes.Include(e => e.Movie).FirstOrDefaultAsync(c => c.Id == id);
            if (episode != null)
            {
                episode.DeletedAt = null;
                _context.Update(episode);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", new { id = episode.MovieId });
        }

        private bool EpisodeExists(string id)
        {
            return _context.episodes.Any(e => e.Id == id);
        }
    }
}

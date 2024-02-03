using X.PagedList;
using Microsoft.AspNetCore.Mvc;

using App.Data;
using App.Areas.Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Utilities;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace App.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("[controller]/[action]")]
    public class MovieController : Controller
    {
        private readonly DataDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MovieController(DataDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Story
        public async Task<IActionResult> Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 10;
            var model = await _context.movies.ToPagedListAsync(pageNumber,pageSize);

            ViewBag.movieIndex = (pageNumber - 1) * pageSize;
            return View(model);
        }

        // GET: Blog/Post/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id != null)
            {
                var movie = await _context.movies
                    .Include(s => s.Episodes)
                    .Include(p => p.CategoryMovie)
                    .ThenInclude(c => c.Category)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (movie != null)
                {
                    //load categories
                    var listCategorys = await _context.CategoryMovie.Where(c => c.MovieId == id).Select(c => c.CategoryId).ToListAsync();
                    var Categorys = await _context.Categories.Where(s => listCategorys.Contains(s.Id)).Select(c => c.Name).ToListAsync();
                    ViewData["categories"] = Categorys;
                    return View(movie);
                }
                return NotFound();
            }
            return NotFound();

        }
        //  GET: Story/Create
        public async Task<IActionResult> Create()
        {
            var categories = await _context.Categories.ToListAsync();

            ViewData["categories"] = new MultiSelectList(categories, "Id", "Name");
            return View();
        }

        // POST: Story/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Author,FileUpload,Status,CategoryIDs")] Movie model)
        {
            //load categories
            var categories = await _context.Categories.ToListAsync();
            ViewData["categories"] = new MultiSelectList(categories, "Id", "Name");

            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid().ToString();
                model.CreatedAt = DateTime.UtcNow;
                model.UpdatedAt = DateTime.UtcNow;
                if (model.FileUpload != null && model.FileUpload.Length > 0) model.FileName = await UploadImage.UploadImageAsync("Image", "Movie" , model.FileUpload);
                _context.Add(model);

                //Add CategoryStory
                if (model.CategoryIDs != null)
                {
                    foreach (var CateId in model.CategoryIDs)
                    {
                        _context.Add(new CategoryMovie()
                        {
                            CategoryId = CateId,
                            Movie = model
                        });
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(model);
        }

        // GET: Story/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //load categories
            var categories = await _context.Categories.ToListAsync();
            var listCategorys = await _context.CategoryMovie.Where(c => c.MovieId == id).Select(c => c.CategoryId).ToListAsync();
            ViewData["categories"] = new MultiSelectList(categories, "Id", "Name", listCategorys);

            var movie = await _context.movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        //  POST: Story/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Description,Author,Status,FileUpload,CategoryIDs")] Movie model)
        {
            if (ModelState.IsValid)
            {
                var movie = _context.movies.Find(id);
                if (movie == null)
                {
                    return NotFound();
                }

                //remove CategoryStory old
                var listCategorys = await _context.CategoryMovie.Where(c => c.MovieId == id).ToListAsync();
                _context.CategoryMovie.RemoveRange(listCategorys);
                
                //Add CategoryStory new
                if (model.CategoryIDs != null)
                {
                    foreach (var CateId in model.CategoryIDs)
                    {
                        _context.Add(new CategoryMovie()
                        {
                            CategoryId = CateId,
                            MovieId = id
                        });
                    }
                }

                // Update image if changed
                if (model.FileUpload != null && model.FileUpload.Length > 0) movie.FileName = await UploadImage.UploadImageAsync("Image", "movie", model.FileUpload);

                movie.Author = model.Author;
                movie.Name = model.Name;
                movie.Description = model.Description;
                movie.Status = model.Status;
                movie.UpdatedAt = DateTime.UtcNow;
                movie.DeletedAt = model.DeletedAt;

                _context.movies.Update(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            //load categories
            var categories = await _context.Categories.ToListAsync();
            var listCategoryActive = await _context.CategoryMovie.Where(c => c.MovieId == id).Select(c => c.CategoryId).ToListAsync();
            ViewData["categories"] = new MultiSelectList(categories, "Id", "Name", listCategoryActive);

            return View(model);
        }

        // GET: Story/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.movies.FirstOrDefaultAsync(c => c.Id == id);
            if (movie != null)
            {
                movie.DeletedAt = DateTime.UtcNow;
                _context.Update(movie);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Story/Delete/5
        public async Task<IActionResult> Restore(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.movies.FirstOrDefaultAsync(c => c.Id == id);
            if (movie != null)
            {
                movie.DeletedAt = null;
                _context.Update(movie);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
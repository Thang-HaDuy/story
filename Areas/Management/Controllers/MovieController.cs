using X.PagedList;
using Microsoft.AspNetCore.Mvc;

using App.Data;
using App.Areas.Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Utilities;
using Microsoft.EntityFrameworkCore.Update.Internal;
using App.Areas.Management.Models.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace App.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("[controller]/[action]")]
    public class MovieController(DataDbContext context, IWebHostEnvironment webHostEnvironment) : Controller
    {
        private readonly DataDbContext _context = context;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        // GET: Story
        public async Task<IActionResult> Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 10;
            var model = await _context.Movies.ToPagedListAsync(pageNumber, pageSize);

            ViewBag.movieIndex = (pageNumber - 1) * pageSize;
            return View(model);
        }

        // GET: Blog/Post/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id != null)
            {
                var movie = await _context.Movies
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
        public async Task<IActionResult> Create(MovieViewModel model)
        {
            //load categories
            var categories = await _context.Categories.ToListAsync();
            ViewData["categories"] = new MultiSelectList(categories, "Id", "Name");

            if (ModelState.IsValid)
            {
                var movie = new Movie()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = model.Name,
                    Description = model.Description,
                    Author = model.Author,
                    Status = model.Status,
                    CreatedAt = DateTime.UtcNow,
                };

                if (model.FileAvatar != null && model.FileAvatar.Length > 0)
                    movie.Avatar = await UploadImage.UploadImageAsync("Image", "Movie", model.FileAvatar!);

                if (model.FileBackground != null && model.FileBackground.Length > 0)
                    movie.Background = await UploadImage.UploadImageAsync("Image", "Movie", model.FileBackground!);

                _context.Add(movie);
                Console.WriteLine(movie.CategoryIDs);

                //Add CategoryStory
                if (movie.CategoryIDs != null)
                {
                    foreach (var CateId in movie.CategoryIDs)
                    {
                        _context.Add(new CategoryMovie()
                        {
                            CategoryId = CateId,
                            Movie = movie
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

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            //load categories
            var categories = await _context.Categories.ToListAsync();
            var listCategorys = await _context.CategoryMovie.Where(c => c.MovieId == id).Select(c => c.CategoryId).ToListAsync();
            ViewData["categories"] = new MultiSelectList(categories, "Id", "Name", listCategorys);

            return View(new MovieUpdateViewModel()
            {
                CategoryIDs = movie.CategoryIDs,
                Author = movie.Author,
                Description = movie.Description,
                Name = movie.Name,
                Status = movie.Status,
            });
        }

        //  POST: Story/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, MovieUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Lặp qua tất cả lỗi trong ModelState
                foreach (var modelState in ModelState)
                {
                    var fieldName = modelState.Key; // Tên thuộc tính (ví dụ: "Title", "Description")
                    foreach (var error in modelState.Value.Errors)
                    {
                        Console.WriteLine($"Field: {fieldName}, Error: {error.ErrorMessage}");
                    }
                }
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                var movie = _context.Movies.Find(id);
                if (movie == null)
                {
                    return NotFound();
                }

                //remove CategoryStory old
                var listCategorys = await _context.CategoryMovie.Where(c => c.MovieId == id).ToListAsync();
                _context.CategoryMovie.RemoveRange(listCategorys);

                // //Add CategoryStory new
                if (!model.CategoryIDs.IsNullOrEmpty())
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

                if (model.FileAvatar != null && model.FileAvatar.Length > 0)
                    movie.Avatar = await UploadImage.UploadImageAsync("Image", "Movie", model.FileAvatar!);

                if (model.FileBackground != null && model.FileBackground.Length > 0)
                    movie.Background = await UploadImage.UploadImageAsync("Image", "Movie", model.FileBackground!);

                movie.Author = model.Author;
                movie.Name = model.Name;
                movie.Description = model.Description;
                movie.Status = model.Status;
                movie.UpdatedAt = DateTime.UtcNow;

                _context.Movies.Update(movie);
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

            var movie = await _context.Movies.FirstOrDefaultAsync(c => c.Id == id);
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

            var movie = await _context.Movies.FirstOrDefaultAsync(c => c.Id == id);
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
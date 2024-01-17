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
    public class StoryController : Controller
    {
        private readonly DataDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StoryController(DataDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Story
        public async Task<IActionResult> Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 10;
            var model = await _context.Stories.ToPagedListAsync(pageNumber,pageSize);

            ViewBag.storyIndex = (pageNumber - 1) * pageSize;
            return View(model);
        }

        // GET: Blog/Post/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id != null)
            {
                var Story = await _context.Stories
                    .Include(s => s.Chapters)
                    .Include(p => p.CategoryStorys)
                    .ThenInclude(c => c.Category)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (Story != null)
                {
                    //load categories
                    var listCategorys = await _context.CategoryStory.Where(c => c.StoryId == id).Select(c => c.CategoryId).ToListAsync();
                    var Categorys = await _context.Categories.Where(s => listCategorys.Contains(s.Id)).Select(c => c.Name).ToListAsync();
                    ViewData["categories"] = Categorys;
                    return View(Story);
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
        public async Task<IActionResult> Create([Bind("Name,Description,Author,FileUpload,Status,CategoryIDs")] Story model)
        {
            //load categories
            var categories = await _context.Categories.ToListAsync();
            ViewData["categories"] = new MultiSelectList(categories, "Id", "Name");

            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid().ToString();
                model.CreatedAt = DateTime.UtcNow;
                model.UpdatedAt = DateTime.UtcNow;
                if (model.FileUpload != null) model.FileName = await UploadImage.UploadImageAsync("Story", model.FileUpload);
                _context.Add(model);

                //Add CategoryStory
                if (model.CategoryIDs != null)
                {
                    foreach (var CateId in model.CategoryIDs)
                    {
                        _context.Add(new CategoryStory()
                        {
                            CategoryId = CateId,
                            Story = model
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
            var listCategorys = await _context.CategoryStory.Where(c => c.StoryId == id).Select(c => c.CategoryId).ToListAsync();
            ViewData["categories"] = new MultiSelectList(categories, "Id", "Name", listCategorys);

            var story = await _context.Stories.FindAsync(id);
            if (story == null)
            {
                return NotFound();
            }
            return View(story);
        }

        //  POST: Story/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Description,Author,Status,FileUpload,CategoryIDs")] Story model)
        {
            if (ModelState.IsValid)
            {
                var story = _context.Stories.Find(id);
                if (story == null)
                {
                    return NotFound();
                }

                //remove CategoryStory old
                var listCategorys = await _context.CategoryStory.Where(c => c.StoryId == id).ToListAsync();
                _context.CategoryStory.RemoveRange(listCategorys);
                
                //Add CategoryStory new
                if (model.CategoryIDs != null)
                {
                    foreach (var CateId in model.CategoryIDs)
                    {
                        _context.Add(new CategoryStory()
                        {
                            CategoryId = CateId,
                            StoryId = id
                        });
                    }
                }

                // Update image if changed
                if (model.FileUpload != null) story.FileName = await UploadImage.UploadImageAsync("Story", model.FileUpload);

                story.Author = model.Author;
                story.Name = model.Name;
                story.Description = model.Description;
                story.Status = model.Status;
                story.UpdatedAt = DateTime.UtcNow;
                story.DeletedAt = model.DeletedAt;

                _context.Stories.Update(story);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            //load categories
            var categories = await _context.Categories.ToListAsync();
            var listCategoryActive = await _context.CategoryStory.Where(c => c.StoryId == id).Select(c => c.CategoryId).ToListAsync();
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

            var story = await _context.Stories.FirstOrDefaultAsync(c => c.Id == id);
            if (story != null)
            {
                story.DeletedAt = DateTime.UtcNow;
                _context.Update(story);
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

            var story = await _context.Stories.FirstOrDefaultAsync(c => c.Id == id);
            if (story != null)
            {
                story.DeletedAt = null;
                _context.Update(story);
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
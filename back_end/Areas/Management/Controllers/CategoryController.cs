using App.Areas.Management.Models;
using App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace App.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("[controller]/[action]")]
    public class CategoryController : Controller
    {

        private readonly DataDbContext _context;

        public CategoryController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Story
        public async Task<IActionResult> Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 10;
            var model = await _context.Categories.ToPagedListAsync(pageNumber,pageSize);
            ViewBag.postIndex = (pageNumber - 1) * pageSize;
            return View(model);
        }

        //  GET: Story/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Story/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Category model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
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

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Story/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name")] Category model)
        {
            if (ModelState.IsValid)
            {
                var cate = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
                if (cate != null) 
                {
                    cate.Name = model.Name;
                    _context.Update(cate);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            return View(model);
        }

        // GET: Story/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var story = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (story == null)
            {
                return NotFound();
            }

            return View(story);
        }

        // POST: Story/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cate = await _context.Categories.FindAsync(id);
            if (cate != null)
            {
                _context.Categories.Remove(cate);
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
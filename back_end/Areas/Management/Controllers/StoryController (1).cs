// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using App.Areas.Management.Models;
// using App.Data;

// namespace App.Areas.Management.Controllers
// {
//     public class StoryController : Controller
//     {
//         private readonly DataDbContext _context;

//         public StoryController(DataDbContext context)
//         {
//             _context = context;
//         }

//         // GET: Story
//         public async Task<IActionResult> Index()
//         {
//             return View(await _context.Stories.ToListAsync());
//         }

//         // GET: Story/Details/5
//         public async Task<IActionResult> Details(string id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var story = await _context.Stories
//                 .FirstOrDefaultAsync(m => m.Id == id);
//             if (story == null)
//             {
//                 return NotFound();
//             }

//             return View(story);
//         }

//         // GET: Story/Create
//         public IActionResult Create()
//         {
//             return View();
//         }

//         // POST: Story/Create
//         // To protect from overposting attacks, enable the specific properties you want to bind to.
//         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Create([Bind("Id,Name,Description,Author,FileName,Status,CreatedAt,UpdatedAt,DeletedAt")] Story story)
//         {
//             if (ModelState.IsValid)
//             {
//                 _context.Add(story);
//                 await _context.SaveChangesAsync();
//                 return RedirectToAction(nameof(Index));
//             }
//             return View(story);
//         }

//         // GET: Story/Edit/5
//         public async Task<IActionResult> Edit(string id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var story = await _context.Stories.FindAsync(id);
//             if (story == null)
//             {
//                 return NotFound();
//             }
//             return View(story);
//         }

//         // POST: Story/Edit/5
//         // To protect from overposting attacks, enable the specific properties you want to bind to.
//         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description,Author,FileName,Status,CreatedAt,UpdatedAt,DeletedAt")] Story story)
//         {
//             if (id != story.Id)
//             {
//                 return NotFound();
//             }

//             if (ModelState.IsValid)
//             {
//                 try
//                 {
//                     _context.Update(story);
//                     await _context.SaveChangesAsync();
//                 }
//                 catch (DbUpdateConcurrencyException)
//                 {
//                     if (!StoryExists(story.Id))
//                     {
//                         return NotFound();
//                     }
//                     else
//                     {
//                         throw;
//                     }
//                 }
//                 return RedirectToAction(nameof(Index));
//             }
//             return View(story);
//         }

//         // GET: Story/Delete/5
//         public async Task<IActionResult> Delete(string id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var story = await _context.Stories
//                 .FirstOrDefaultAsync(m => m.Id == id);
//             if (story == null)
//             {
//                 return NotFound();
//             }

//             return View(story);
//         }

//         // POST: Story/Delete/5
//         [HttpPost, ActionName("Delete")]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> DeleteConfirmed(string id)
//         {
//             var story = await _context.Stories.FindAsync(id);
//             if (story != null)
//             {
//                 _context.Stories.Remove(story);
//             }

//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Index));
//         }

//         private bool StoryExists(string id)
//         {
//             return _context.Stories.Any(e => e.Id == id);
//         }
//     }
// }

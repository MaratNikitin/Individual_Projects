using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBEntities.Models;

/*
 * This ASP.NET Core 7 MVC web app allows displaying items grouped by categories coming from a SQL Server database 
    using Entity Framework Core; full range of CRUD operations is enabled.
 *  This is the only controller file of the application.
 * Author: Marat Nikitin
 * Assignment
 * When: March 2023
 */

namespace MVC.Controllers
{
    public class ItemsController : Controller
    {
        private readonly Assignment2023Context _context;

        public ItemsController(Assignment2023Context context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var categoriesList = await _context.Categories.ToListAsync();     
            var assignment2023Context = _context.Items.Include(i => i.Category);
            decimal grandTotal = 0;

            // This dictionary object holds category names and their total item values.
            Dictionary<string, decimal> categoriesWithTotals = new();

            foreach (var category in categoriesList)
            {
                var categoryItems = _context.Items.Where(i => i.CategoryId == category.CategoryId);
                decimal categoryTotal = categoryItems.Sum(i => i.ItemValue);
                grandTotal += categoryTotal;
                categoriesWithTotals.Add(category.CategoryName.ToString(), categoryTotal);
            }
            ViewBag.CategoriesWithTotals = categoriesWithTotals;
            ViewBag.GrandTotal = grandTotal;
            return View(await assignment2023Context.OrderBy(i => i.CategoryId).ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Category)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,CategoryId,ItemName,ItemValue")] Item item)
        {
            ModelState.Remove("Category"); // this enables proper validation 
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", item.CategoryId);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", item.CategoryId);
            return View(item);
        }


        // POST: Items/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,CategoryId,ItemName,ItemValue")] Item item)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }
            ModelState.Remove("Category"); // this enables proper validation 
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", item.CategoryId);
            return View(item);
        }


        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Category)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }


        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Items == null)
            {
                return Problem("Entity set 'Assignment2023Context.Items'  is null.");
            }
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool ItemExists(int id)
        {
          return (_context.Items?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
    }
}

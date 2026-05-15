using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _context.Categories.Include(c => c.Products).Where(c => !c.IsDeleted).ToListAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool existsCategory = await _context.Categories.AnyAsync(c => c.Name.Trim() == category.Name.Trim());

            if (existsCategory)
            {
                ModelState.AddModelError("Name", "This category already exists");
                return View();
            }

            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null || id < 1) return NotFound();
            Category? category = await _context.Categories
                .Where(c => !c.IsDeleted)
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (category is null) return NotFound();
            return View(category);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return NotFound();
            Category? existCategory = await _context.Categories
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (existCategory is null) return NotFound();
            return View(existCategory);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, Category category)
        {
            if (id is null || id < 1) return NotFound();
            Category? existCategory = await _context.Categories
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (existCategory is null) return NotFound();
            if (!ModelState.IsValid) return View(existCategory);
            bool result = await _context.Categories.AnyAsync(c => c.Name.Trim() == category.Name.Trim() && c.Id != id);
            if (result)
            {
                ModelState.AddModelError("Name", "This category already exists");
                return View(existCategory);
            }
            existCategory.Name = category.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1) return NotFound();
            Category? existCategory = await _context.Categories
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (existCategory is null) return NotFound();
            _context.Categories.Remove(existCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

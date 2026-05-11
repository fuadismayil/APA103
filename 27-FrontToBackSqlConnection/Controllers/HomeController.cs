using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class HomeController : Controller
    {
        // DI - Dependency Injection
        // IOC - Inversion of Control
        // DIP - Dependency Inversion Principle

        // DC - Dependency Container
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        //List<Slider> ssliders = new List<Slider>
        //{
        //    new Slider{Title="basliq 1", Subtitle="elave basliq 1", Description="bura aciqlamalar gelecek 1", IsDeleted=false, Order=1,CreatedAt=DateTime.Now, Image="1-1-524x617.png"},
        //    new Slider{Title="basliq 2", Subtitle="elave basliq 2", Description="bura aciqlamalar gelecek 2", IsDeleted=false, Order=2,CreatedAt=DateTime.Now, Image="1-2-524x617.png"},
        //    new Slider{Title="basliq 3", Subtitle="elave basliq 3", Description="bura aciqlamalar gelecek 3", IsDeleted=false, Order=3,CreatedAt=DateTime.Now, Image="1-1-270x300.jpg"},

        //};


        public async Task<IActionResult> Index()
        {
            //_context.AddRange(ssliders);
            //_context.SaveChanges();

            //Product product = _context.Products.Include(p=>p.Category).FirstOrDefault();
            //Category category = _context.Categories.FirstOrDefault(c=>c.Id==product.CategoryId);

            List<Slider> sliders = await _context.Sliders
                .Where(s => !s.IsDeleted)
                .OrderBy(s => s.Order)
                .ToListAsync();

            List<Product> products = await _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.ProductImages)
                .ToListAsync();

            HomeVM homeVM = new()
            {
                Sliders = sliders,
                Products = products
            };
            return View(homeVM);
        }
    }
}

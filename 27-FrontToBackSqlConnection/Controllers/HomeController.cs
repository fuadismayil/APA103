using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.View_Models;
using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        //List<Slider> _sliders = new List<Slider>
        //{
        //    new Slider{Title="basliq 1", Subtitle="elave basliq 1", Description="bura aciqlamalar gelecek 1", IsDeleted=false, Order=1,CreatedAt=DateTime.Now, Image="1-1-524x617.png"},
        //    new Slider{Title="basliq 2", Subtitle="elave basliq 2", Description="bura aciqlamalar gelecek 2", IsDeleted=false, Order=2,CreatedAt=DateTime.Now, Image="1-2-524x617.png"},
        //    new Slider{Title="basliq 3", Subtitle="elave basliq 3", Description="bura aciqlamalar gelecek 3", IsDeleted=false, Order=3,CreatedAt=DateTime.Now, Image="1-1-270x300.jpg"},

        //};


        public IActionResult Index()
        {
            //_context.AddRange(_sliders);
            //_context.SaveChanges();
            List<Slider> _sliders = _context.Sliders
                .Where(s => !s.IsDeleted)
                .OrderBy(s => s.Order)
                .ToList();
            HomeVM homeVM = new()
            {
                Sliders = _sliders
            };
            return View(homeVM);
        }
    }
}

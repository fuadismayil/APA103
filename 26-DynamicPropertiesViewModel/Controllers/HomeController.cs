using _26_DynamicPropertiesViewModel.Models;
using _26_DynamicPropertiesViewModel.ViewModels;
using _26_DynamicPropertiesViewModel.Models;
using _26_DynamicPropertiesViewModel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _26_DynamicPropertiesViewModel.Controllers
{
    public class HomeController : Controller
    {
        private List<Student> _students = new List<Student>
        {
            new Student
            {
                Id = 1,
                Name = "Rauf",
                Age = 20
            },
            new Student
            {
                Id = 2,
                Name = "Günel",
                Age = 19
            },
            new Student
            {
                Id = 3,
                Name = "Aysu",
                Age = 19
            }
        };

        private List<Teacher> _teachers = new List<Teacher>
        {
            new Teacher
            {
                Id = 1,
                Name = "Eli",
                Salary = 500
            },
            new Teacher
            {
                Id = 2,
                Name = "Veli müəllim",
                Salary = 4200
            }
        };

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM();

            homeVM.Students = _students;
            homeVM.Teachers = _teachers;

            return View(homeVM);
        }

        /* public IActionResult Index()
        {
            List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "Rauf", Age = 20 },
                new Student { Id = 2, Name = "Günel", Age = 19 },
                new Student { Id = 3, Name = "Aysu", Age = 19 }
            };
            ViewBag.Students = students;
            return View();
        } */



        /* public IActionResult Index()
        {
            List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "Rauf", Age = 20 },
                new Student { Id = 2, Name = "Günel", Age = 19 },
                new Student { Id = 3, Name = "Aysu", Age = 19 }
            };
            ViewData["Students"] = students;
            return View();
        } */



        /* public IActionResult Index()
        {
            TempData["Name"] = "Ruslan";
            return View();
        } */



        public IActionResult CorporateSales()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
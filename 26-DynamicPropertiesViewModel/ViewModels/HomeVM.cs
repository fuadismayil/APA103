using _26_DynamicPropertiesViewModel.Models;

namespace _26_DynamicPropertiesViewModel.ViewModels
{
    public class HomeVM
    {
        public List<Student> Students { get; set; } = new List<Student>();

        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}

using System.ComponentModel.DataAnnotations;

namespace _27_FrontToBackSqlConnection.Models
{
    public class Category:BaseEntity
    {
        [Required(ErrorMessage = "Bu xana bos ola bilmez")]
        [MaxLength(30, ErrorMessage = "Aqilli ol")]
        public string? Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}

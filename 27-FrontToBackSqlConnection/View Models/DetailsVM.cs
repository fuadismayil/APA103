using _27_FrontToBackSqlConnection.Models;

namespace _27_FrontToBackSqlConnection.View_Models
{
    public class DetailsVM
    {
        internal List<Product> RelatedProduct;

        public Product Product { get; set; }
        public List<Product> RelatedProducts { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.RepositoryLayer.Models
{
    public class Product
    {
        [Key]
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int QuantityInStock { get; set; }
        public string Category { get; set; }

    }
}

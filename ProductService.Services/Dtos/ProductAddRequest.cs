namespace ProductService.ServiceLayer.Dtos
{
    public class ProductAddRequest
    {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int QuantityInStock { get; set; }
        public CategoryOptions Category { get; set; }
    }
}

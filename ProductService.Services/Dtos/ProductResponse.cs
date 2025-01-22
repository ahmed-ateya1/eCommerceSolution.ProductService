namespace ProductService.ServiceLayer.Dtos
{
    public class ProductResponse
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int QuantityInStock { get; set; }
        public string Category { get; set; }
    }
}

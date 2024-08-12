namespace PaparaProjectSchema.Requests
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string? Features { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public decimal PointMultiplierPercentage { get; set; }
        public ICollection<ProductCategoryMapRequest>? ProductCategoryMaps { get; set; }
    }
}

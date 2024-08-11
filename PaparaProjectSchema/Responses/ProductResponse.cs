using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectSchema.Responses
{
    public class ProductResponse
    {
        public string Name { get; set; }
        public string? Features { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public decimal PointMultiplierPercentage { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectSchema.Requests
{
    public class CategoryRequest
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string? Tags { get; set; }
        //public ICollection<ProductCategoryMapRequest> ProductCategoryMaps { get; set; }
    }
}

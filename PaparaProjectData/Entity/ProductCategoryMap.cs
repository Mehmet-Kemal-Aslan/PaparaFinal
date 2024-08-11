using PaparaFinalBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaFinalData.Entity
{
    public class ProductCategoryMap : BaseEntity
    {
        public int CategoryId { get; set; }
        public Category Categories { get; set; }

        public int ProductId { get; set; }
        public Product Products { get; set; }
    }
}

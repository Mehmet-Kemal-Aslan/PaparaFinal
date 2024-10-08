﻿using PaparaFinalBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaFinalData.Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string? Features { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public decimal PointMultiplierPercentage { get; set; }
        public ICollection<BasketItem>? BasketItems { get; set; }
        public ICollection<ProductCategoryMap>? ProductCategoryMaps { get; set; }
    }
}

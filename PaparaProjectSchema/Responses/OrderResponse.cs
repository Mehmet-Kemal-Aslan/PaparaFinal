﻿using PaparaProjectSchema.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectSchema.Responses
{
    public class OrderResponse
    {
        public string UserId { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
        public DateTime DateTime { get; set; }
        public int BasketId { get; set; }
        public ICollection<OrderDetailResponse> OrderDetails { get; set; }
    }
}

﻿using System.Collections.Generic;

namespace GraphQLDotNet.Models
{
    public class Item
    {
        public string Barcode { get; set; }
        public string Title { get; set; }
        public decimal SellingPrice { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}

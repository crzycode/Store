using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.Functions
{
    public class AddCart
    {
        public string user { get; set; }
        public int Product_id { get; set; }
        public int price { get; set; }
        public int product_quantity { get; set; }
    }
}
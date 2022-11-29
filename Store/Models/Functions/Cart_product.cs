using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.Functions
{
    public class Cart_product
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string price { get; set; }
        public string image { get; set; }
        public int quantity { get; set; }
        

    }
}
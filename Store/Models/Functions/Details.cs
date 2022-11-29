using Store.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.Functions
{
    public class Details
    {
        public IEnumerable<Product> Product { get; set; }
        public string[] image { get; set; }
        public string price { get; set; }
        public int discount { get; set; }
        public double mrp { get; set; }
        public string[] specification { get; set; }
        public string[] about { get; set; }
        public int product_id { get; set; }
        public string user { get; set; }

    }
}
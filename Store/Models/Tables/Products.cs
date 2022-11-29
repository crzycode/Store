using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models.Tables
{
    public class Product
    {
        [Key]
        public int product_id { get; set; }
        public string Uniq_Id { get; set; }
        public string Product_Name { get; set; }
        public string Category { get; set; }
        public string Selling_Price { get; set; }
        public string Model_Number { get; set; }
        public string About_Product { get; set; }
        public string Product_Specification { get; set; }
        public string Technical_Details { get; set; }
        public string Shipping_Weight { get; set; }
        public string Images { get; set; }
        public string Variants { get; set; }
        public string Sku { get; set; }
        public string Product_Url { get; set; }
    }
  
}
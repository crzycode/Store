using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.Functions
{
    public class cartdataget
    {
        public IEnumerable<Cart_product>[] cart { get; set; }
        public double  totalamount { get; set; }
    }
}
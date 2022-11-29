using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Store.Models.DataContexts;
using Store.Models.Functions;
using Store.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class DetailsController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Index(int id)
        {
            var data = db.A_products.Where(x => x.product_id == id).ToList();
            List<Product> product = new List<Product>();
            Details d = new Details();

            string[] mangal = new string[] { };
            string[] About = new string[] { };

            foreach (var item in data)
            {
                
                string[] img = item.Images.Split('|');
                Product pro = new Product();
                pro.product_id = item.product_id;
                pro.Product_Name = item.Product_Name;
                pro.Selling_Price = item.Selling_Price;
                pro.Category = item.Category;
                pro.Images = img[0];
                pro.Product_Specification = item.Product_Specification;
                pro.Product_Url = item.Product_Url;
                pro.Shipping_Weight = item.Shipping_Weight;
                pro.Sku = item.Sku;
                pro.Technical_Details = item.Technical_Details;
                pro.Variants = item.Variants;
                pro.Uniq_Id = item.Uniq_Id;
                pro.Model_Number = item.Model_Number;
                pro.About_Product = item.About_Product;
                product.Add(pro);
                /*selling price*/
                string[] selling = item.Selling_Price.Split('$');
                Random rnd = new Random();
                int discount = rnd.Next(1, 20);
                double price = Convert.ToDouble(discount * Convert.ToDouble(selling[1]) / 100);
                Double mrp = Convert.ToDouble(price + Convert.ToDouble(selling[1]));
                mrp = (double)System.Math.Round(mrp, 2);
                /*product specification*/
                if (item.Product_Specification != null)
                {
                    string[] spec = item.Product_Specification.Split('|');
                    mangal = spec;

                }
                /*About Product*/
                if (item.About_Product != null)
                {
                    string[] about = item.About_Product.Split('|');
                    About = about;
                }





                d.Product = product;
                d.image = img;
                d.mrp = mrp;
                d.discount = discount;
                d.price = selling[1];
                d.specification = mangal;
                d.about = About;
                d.product_id = item.product_id;
             

            }



            return View(d);
        }
        [HttpPost]
        public dynamic details()
        {

            List<dynamic> Message = new List<dynamic>();

            dynamic message = new
            {
                Message = "Success"
            };
            Message.Add(message);

            var data = JsonConvert.SerializeObject(message);



            return data;
        }

    }
}
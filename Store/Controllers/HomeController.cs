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
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            
            if(Session["user"] != null) 
            {

                return View();
            }
            return RedirectToAction("Index", "Registration");
            
        }
       
     
        public dynamic allproduct()
        {
            List<dynamic> da = new List<dynamic>();

          
            var data = db.A_products.Take(50).ToList();
            
            for (int i = 0; i < data.Count; i++)
            {
                List<dynamic> category = new List<dynamic>();
                List<dynamic> productname = new List<dynamic>();
                dynamic A_Products = new JObject();
                char[] spearator = {'|'};
                char[] spearator1 = { ',',' ','|','-',':' };
                if(data[i].Category == null)
                {
                    category.Add("default");
                }
                else
                {
                    string[] cat = data[i].Category.Split(spearator1);
                    if(cat.Length > 3)
                    {
                        string cate = string.Join(" ", cat[0], cat[1], cat[2], cat[3], cat[4]);
                        category.Add(cate);
                    }
                    else
                    {
                        string cate = string.Join(" ", cat[0], cat[1]);
                        category.Add(cate);
                    }
                  

                }
                string[] pro = data[i].Product_Name.Split(spearator1);
                if (pro.Length > 2)
                {
                  
                    string product_name = string.Join(" ", pro[0],pro[1],pro[2]);
                    productname.Add(product_name);
                }
                else
                {
                    
                    string product_name = string.Join(" ", pro[0]);
                    productname.Add(product_name);
                }
                string[] prices = data[i].Selling_Price.Split('$');
                var dat = productname.ToList();
                A_Products.Product_Name = dat[0];
                A_Products.Category = category[0];
                A_Products.Images = data[i].Images;
                A_Products.Selling_Price = " ₹"+prices[1];
                A_Products.product_id = data[i].product_id;
               

                da.Add(A_Products);




            }
           

            var json = JsonConvert.SerializeObject(da);
            return json;
        }
        

    }
}
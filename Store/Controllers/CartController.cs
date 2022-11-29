using Store.Models.DataContexts;
using Store.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Models.Tables;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace Store.Controllers
{
    public class CartController : Controller
    {
        DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
           



            return View();
        }
        
        public dynamic gotocart(string user)
        {
            List<dynamic> key = new List<dynamic>();
            List<dynamic> values = new List<dynamic>();
            JsonManagement.JsonCon(1);
            var get_list = System.IO.File.ReadAllText($@"D:\VisualStudioProject\Store\Store\Cart\cart.json");
            dynamic des_cart = JsonConvert.DeserializeObject<List<dynamic>>(get_list);
            for (int i = 0; i < des_cart.Count; i++)
            {
                if (des_cart[i].user == user)
                {
                    foreach (var item in des_cart[i].product_quantity)
                    {
                        var data = JsonConvert.SerializeObject(item);
                        string[] keypairs = data.Split(':');

                        string keys = Regex.Match(keypairs[0], @"\d+").Value;
                        string value = Regex.Match(keypairs[1], @"\d+").Value;
                        key.Add(keys);
                        values.Add(value);
                    }
                }
            }
            LinkedList<dynamic> cart_data = new LinkedList<dynamic>();
            double totalprice = 0;
            for (int i = 0; i < key.Count; i++)
            {
                int id = Convert.ToInt32(key[i]);
                int count = Convert.ToInt32(values[i]);

                    var data = db.A_products.Where(x => x.product_id == id).ToList();
                
                
              
                for (int j   = 0; j < data.Count; j++)
                {
                    string[] prices = data[j].Selling_Price.Split('$');
                    string stringprice = prices[1];
                    Double price = Convert.ToDouble(stringprice);
                    int x = Convert.ToInt32(values[i]);
                    double intox = price * x;
                    totalprice = totalprice + intox;
                  
                    Cart_product cart_Product = new Cart_product();
                    cart_Product.product_id = data[j].product_id;
                    cart_Product.product_name = data[j].Product_Name;
                    cart_Product.image = data[j].Images;
                    cart_Product.price = stringprice;
                    cart_Product.quantity = count;

                    cart_data.AddLast(cart_Product);
                }
                    
                   
                
              
               

            }

            totalprice = (double)System.Math.Round(totalprice, 2);

            cart_data.AddFirst(totalprice);



            var json = JsonConvert.SerializeObject(cart_data);
          
            return json;
        }
        [HttpPost]
        public dynamic addtocart(AddCart c)
        {
            int[] counter = new int[3];
            int qty = 0;
            if (!System.IO.File.Exists($@"D:\VisualStudioProject\Store\Store\Cart\cart.json"))
            {
                System.IO.File.Create($@"D:\VisualStudioProject\Store\Store\Cart\cart.json").Dispose();
                System.IO.File.WriteAllText($@"D:\VisualStudioProject\Store\Store\Cart\cart.json", "[\n]");
            }
            JsonManagement.JsonCon(1);
            var get_list = System.IO.File.ReadAllText($@"D:\VisualStudioProject\Store\Store\Cart\cart.json");
           
            dynamic des_cart = JsonConvert.DeserializeObject<List<dynamic>>(get_list);
            if(des_cart.Count != 0)
            {
                bool check = true;
                for (int i = 0; i < des_cart.Count; i++)
                {
                    if(des_cart[i].user == c.user)
                    {

                        if(des_cart[i]["product_quantity"].ContainsKey($"{c.Product_id}"))
                        {
                            des_cart[i]["product_quantity"][$"{c.Product_id}"] = des_cart[i]["product_quantity"][$"{c.Product_id}"] + 1;
                            des_cart[i]["totalamount"] = des_cart[i]["totalamount"] + c.price;
                            des_cart[i]["total"] = des_cart[i]["total"] + 1;
                           
                            counter[0] = des_cart[i]["product_quantity"][$"{c.Product_id}"];
                            counter[1] = des_cart[i]["total"] = des_cart[i]["total"];
                            counter[2] = des_cart[i]["totalamount"];
                            var json = JsonConvert.SerializeObject(des_cart, Formatting.Indented);
                           System.IO.File.WriteAllText($@"D:\VisualStudioProject\Store\Store\Cart\cart.json", json);
                            check = false;
                            JsonManagement.JsonCon(2);
                        }
                        else
                        {
                           
                            des_cart[i].product_quantity.Add($"{c.Product_id}", 1);
                            if (des_cart[i]["product_quantity"][$"{c.Product_id}"] == 1)
                            {
                                des_cart[i]["total"] = des_cart[i]["total"] + 2;
                                des_cart[i]["totalamount"] = des_cart[i]["totalamount"] + c.price+c.price;
                                des_cart[i]["product_quantity"][$"{c.Product_id}"] = des_cart[i]["product_quantity"][$"{c.Product_id}"] + 1;
                            }
                           

                            counter[0] = des_cart[i]["product_quantity"][$"{c.Product_id}"];
                            counter[1]= des_cart[i]["total"] = des_cart[i]["total"];
                            counter[2] = des_cart[i]["totalamount"];

                            var json = JsonConvert.SerializeObject(des_cart, Formatting.Indented);
                          
                            System.IO.File.WriteAllText($@"D:\VisualStudioProject\Store\Store\Cart\cart.json", json);
                            check = false;
                            JsonManagement.JsonCon(2);
                        }
                    }
 
                }

                if (check == true)
                {
                    
                        var readdata = System.IO.File.ReadAllLines($@"D:\VisualStudioProject\Store\Store\Cart\cart.json").ToList();

                        dynamic product = new JObject();
                        product.user = c.user;
                        product.total = 1;
                        product.totalamount = c.price;
                        product.product_quantity = new JObject();

                        product.product_quantity.Add($"{c.Product_id}", 1);
                        var json = JsonConvert.SerializeObject(product, Formatting.Indented);
                        readdata.Insert(1,  json+",");
                        System.IO.File.WriteAllLines($@"D:\VisualStudioProject\Store\Store\Cart\cart.json", readdata);
                    
                }
            }

            return Json(counter, JsonRequestBehavior.AllowGet);
        }
        public dynamic removefromcart(AddCart c)
        {
            int[] counter = new int[3];
            int qty =0;
            JsonManagement.JsonCon(1);
            var get_list = System.IO.File.ReadAllText($@"D:\VisualStudioProject\Store\Store\Cart\cart.json");
            
            dynamic des_cart = JsonConvert.DeserializeObject<List<dynamic>>(get_list);
            if (des_cart.Count != 0)
            {
               
                for (int i = 0; i < des_cart.Count; i++)
                {
                    if (des_cart[i].user == c.user)
                    {

                        if (des_cart[i]["product_quantity"].ContainsKey($"{c.Product_id}"))
                        {
                            if (des_cart[i]["product_quantity"][$"{c.Product_id}"] != 0)
                            {
                                des_cart[i]["product_quantity"][$"{c.Product_id}"] = des_cart[i]["product_quantity"][$"{c.Product_id}"] - 1;
                                des_cart[i]["totalamount"] = des_cart[i]["totalamount"] - c.price;
                                des_cart[i]["total"] = des_cart[i]["total"] - 1;
                                counter[0] = des_cart[i]["product_quantity"][$"{c.Product_id}"];
                                counter[1]= des_cart[i]["total"] = des_cart[i]["total"];
                                counter[2] = des_cart[i]["totalamount"];
                                var json = JsonConvert.SerializeObject(des_cart, Formatting.Indented);
                                System.IO.File.WriteAllText($@"D:\VisualStudioProject\Store\Store\Cart\cart.json", json);
                                JsonManagement.JsonCon(2);
                            }
                            else
                            {
                                return "value already 0";
                            }
                        }
                      
                    }

                }

            }

            return Json(counter,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public dynamic total_count(string user)
        {
             int qnt = 0;
             JsonManagement.JsonCon(1);
             var get_list = System.IO.File.ReadAllText($@"D:\VisualStudioProject\Store\Store\Cart\cart.json");

             dynamic des_cart = JsonConvert.DeserializeObject<List<dynamic>>(get_list);
             for (int i = 0; i < des_cart.Count; i++)
             {
                 if (des_cart[i].user == user)
                 {
                     qnt = des_cart[i]["total"];
                 }
             }

             return Json(qnt, JsonRequestBehavior.AllowGet);
            
        }
    }
}
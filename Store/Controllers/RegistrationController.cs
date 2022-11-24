﻿using Newtonsoft.Json;
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
    public class RegistrationController : Controller
    {
        // GET: Registration
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Register(User u)
        {
            List<dynamic> error = new List<dynamic>();
            var email = db.users.Where(x => x.User_email == u.User_email).FirstOrDefault();
            var mobile = db.users.Where(x => x.User_mobile == u.User_mobile).FirstOrDefault();
            bool emailcheck = false;
            bool mobilecheck = false;
            if(email != null)
            {
                error.Add("Email Already Register");
                emailcheck = true;
            }
            if (mobile != null)
            {
                error.Add("Mobile Already Register");
                mobilecheck = true;
            }
            
          if(mobilecheck != true &&  emailcheck != true)
            {
                db.users.Add(u);
                db.SaveChanges();
                error.Add("success");
            }

            var json = JsonConvert.SerializeObject(error);
            
            return json;
        }
        [HttpPost]
        public string Login(Login l)
        {
            List<dynamic> Messsage = new List<dynamic>();
           
            var email = db.users.Where(x => x.User_email == l.Email && x.User_password == l.Password).ToList();

            var mobile = db.users.Where(x => x.User_mobile == l.Mobile && x.User_password == l.Password).ToList();
            if (email.Count == 1)
            {
                foreach (var item in email)
                {
                    Session["email"] = item.User_email;
                }
                Messsage.Add("success");
                var json1 = JsonConvert.SerializeObject(Messsage);
                return json1;
            
            }
            if(mobile.Count == 1)
            {
                foreach (var item in mobile)
                {
                    Session["mobile"] = item.User_mobile;
                }
                Messsage.Add("success");
                var json2 = JsonConvert.SerializeObject(Messsage);
                return json2;
                
            }
            Messsage.Add("User Not Valid");
            var json = JsonConvert.SerializeObject(Messsage);
            return json;
        }
    }
}
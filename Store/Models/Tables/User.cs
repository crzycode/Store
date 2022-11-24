using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models.Tables
{
    public class User
    {
        [Key]
        public int User_id { get; set; }
        public string User_name { get; set; }
        public string User_email { get; set; }
        public long User_mobile { get; set; }
        public string User_password { get; set; }
        public string created_at { get; set; } = DateTime.Now.ToString();

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models.Tables
{
    public class Country
    {
        [Key]
        public int C_id { get; set; }
        public string PostOfficeName { get; set; }
        public int Pincode { get; set; }
        public string DistrictsName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}

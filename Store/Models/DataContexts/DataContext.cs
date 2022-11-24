using Store.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Store.Models.DataContexts
{
    public class DataContext:DbContext
    {
        public DataContext():base("OktaConnectionString")
        {

        }
        public DataContext Create()
        {
            return new DataContext();
        }
        public DbSet<Country> countries { get; set; }
        public DbSet<A_Products> A_products { get; set; }
        public DbSet<User> users { get; set; }

    }
}
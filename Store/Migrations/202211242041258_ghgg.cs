namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghgg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.A_Products",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        Uniq_Id = c.String(),
                        Product_Name = c.String(),
                        Category = c.String(),
                        Selling_Price = c.String(),
                        Model_Number = c.String(),
                        About_Product = c.String(),
                        Product_Specification = c.String(),
                        Technical_Details = c.String(),
                        Shipping_Weight = c.String(),
                        Variants = c.String(),
                        Sku = c.String(),
                        Product_Url = c.String(),
                    })
                .PrimaryKey(t => t.product_id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        C_id = c.Int(nullable: false, identity: true),
                        PostOfficeName = c.String(),
                        Pincode = c.Int(nullable: false),
                        DistrictsName = c.String(),
                        City = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.C_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_id = c.Int(nullable: false, identity: true),
                        User_name = c.String(),
                        User_email = c.String(),
                        User_mobile = c.Long(nullable: false),
                        User_password = c.String(),
                        created_at = c.String(),
                    })
                .PrimaryKey(t => t.User_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Countries");
            DropTable("dbo.A_Products");
        }
    }
}

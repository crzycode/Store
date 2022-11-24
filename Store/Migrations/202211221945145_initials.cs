namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initials : DbMigration
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
                        Images = c.String(),
                        Variants = c.String(),
                        Sku = c.String(),
                        Product_Url = c.String(),
                    })
                .PrimaryKey(t => t.product_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.A_Products");
        }
    }
}

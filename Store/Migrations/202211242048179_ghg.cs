namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Images", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Images");
        }
    }
}

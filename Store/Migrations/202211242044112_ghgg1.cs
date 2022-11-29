namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghgg1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.A_Products", newName: "Products");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Products", newName: "A_Products");
        }
    }
}

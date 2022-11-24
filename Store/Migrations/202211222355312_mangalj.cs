namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mangalj : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "created_at", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "created_at", c => c.Int(nullable: false));
        }
    }
}

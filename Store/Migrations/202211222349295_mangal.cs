namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mangal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_id = c.Int(nullable: false, identity: true),
                        User_name = c.String(),
                        User_email = c.String(),
                        User_mobile = c.Long(nullable: false),
                        User_password = c.String(),
                        created_at = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.User_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}

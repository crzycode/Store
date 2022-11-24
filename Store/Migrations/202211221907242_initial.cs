namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Countries");
        }
    }
}

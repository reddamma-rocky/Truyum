namespace Truyum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Truyumschema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        price = c.Single(nullable: false),
                        active = c.Boolean(nullable: false),
                        dateOfLaunch = c.DateTime(nullable: false),
                        category = c.String(nullable: false),
                        freeDelivery = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MenuItems");
        }
    }
}

namespace Truyum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TruyumContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        MenuItemId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartId);
            
            AddColumn("dbo.MenuItems", "Carts_CartId", c => c.Int());
            CreateIndex("dbo.MenuItems", "Carts_CartId");
            AddForeignKey("dbo.MenuItems", "Carts_CartId", "dbo.Carts", "CartId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItems", "Carts_CartId", "dbo.Carts");
            DropIndex("dbo.MenuItems", new[] { "Carts_CartId" });
            DropColumn("dbo.MenuItems", "Carts_CartId");
            DropTable("dbo.Carts");
        }
    }
}

namespace ByingApplications.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedProductTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Fabric", c => c.String());
            AddColumn("dbo.Products", "Color", c => c.String());
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "UnitPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Description", c => c.String());
            AddColumn("dbo.Products", "Category_Id", c => c.Int());
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropColumn("dbo.Products", "Category_Id");
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Products", "UnitPrice");
            DropColumn("dbo.Products", "Quantity");
            DropColumn("dbo.Products", "Color");
            DropColumn("dbo.Products", "Fabric");
            DropTable("dbo.Categories");
        }
    }
}

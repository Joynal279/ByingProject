namespace ByingApplications.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InhancedProductTableProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "AddedDate", c => c.DateTime());
            AddColumn("dbo.Products", "AddedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "AddedBy");
            DropColumn("dbo.Products", "AddedDate");
        }
    }
}

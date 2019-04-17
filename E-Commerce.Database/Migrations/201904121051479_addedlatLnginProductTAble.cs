namespace E_Commerce.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlatLnginProductTAble : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "latitude", c => c.String());
            AddColumn("dbo.Products", "longitude", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "longitude");
            DropColumn("dbo.Products", "latitude");
        }
    }
}

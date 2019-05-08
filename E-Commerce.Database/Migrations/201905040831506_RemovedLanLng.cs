namespace E_Commerce.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedLanLng : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "latitude");
            DropColumn("dbo.Products", "longitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "longitude", c => c.String());
            AddColumn("dbo.Products", "latitude", c => c.String());
        }
    }
}

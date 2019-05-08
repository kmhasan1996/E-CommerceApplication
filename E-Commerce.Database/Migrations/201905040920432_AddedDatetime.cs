namespace E_Commerce.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDatetime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CreatedTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "CreatedTime");
        }
    }
}

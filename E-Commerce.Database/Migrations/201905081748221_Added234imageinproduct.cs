namespace E_Commerce.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added234imageinproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageURL2", c => c.String());
            AddColumn("dbo.Products", "ImageURL3", c => c.String());
            AddColumn("dbo.Products", "ImageURL4", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ImageURL4");
            DropColumn("dbo.Products", "ImageURL3");
            DropColumn("dbo.Products", "ImageURL2");
        }
    }
}

namespace E_Commerce.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFoodandMedicineTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodandMedicines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Month = c.String(),
                        MinWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Food = c.String(),
                        Medicine = c.String(),
                        Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .Index(t => t.Category_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodandMedicines", "Category_ID", "dbo.Categories");
            DropIndex("dbo.FoodandMedicines", new[] { "Category_ID" });
            DropTable("dbo.FoodandMedicines");
        }
    }
}

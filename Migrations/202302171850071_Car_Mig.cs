namespace Cars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Car_Mig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "CarCat_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "CarCat_Id");
            AddForeignKey("dbo.Cars", "CarCat_Id", "dbo.CarCats", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CarCat_Id", "dbo.CarCats");
            DropIndex("dbo.Cars", new[] { "CarCat_Id" });
            DropColumn("dbo.Cars", "CarCat_Id");
        }
    }
}

namespace Passion_project_Jaskaran_n01664609.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ingredients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        IngredientID = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(),
                    })
                .PrimaryKey(t => t.IngredientID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ingredients");
        }
    }
}

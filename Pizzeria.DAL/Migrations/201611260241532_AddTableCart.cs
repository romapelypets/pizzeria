namespace Pizzeria.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CartId = c.String(nullable: false),
                        PizzaId = c.Long(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pizza", t => t.PizzaId)
                .Index(t => t.PizzaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart", "PizzaId", "dbo.Pizza");
            DropIndex("dbo.Cart", new[] { "PizzaId" });
            DropTable("dbo.Cart");
        }
    }
}

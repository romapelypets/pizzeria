namespace Pizzeria.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrderTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PizzaToOrder",
                c => new
                    {
                        PizzaId = c.Long(nullable: false),
                        OrderId = c.Long(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TimeAll = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => new { t.PizzaId, t.OrderId })
                .ForeignKey("dbo.Pizza", t => t.PizzaId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.PizzaId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Pizza",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Time = c.Time(nullable: false, precision: 7),
                        PizzaMakerId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PizzaMaker", t => t.PizzaMakerId)
                .Index(t => t.PizzaMakerId);
            
            CreateTable(
                "dbo.PizzaMaker",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductToPizza",
                c => new
                    {
                        PizzaId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.PizzaId, t.ProductId })
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Pizza", t => t.PizzaId, cascadeDelete: true)
                .Index(t => t.PizzaId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Time = c.Time(nullable: false, precision: 7),
                        Count = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PizzaToOrder", "OrderId", "dbo.Order");
            DropForeignKey("dbo.ProductToPizza", "PizzaId", "dbo.Pizza");
            DropForeignKey("dbo.ProductToPizza", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Pizza", "PizzaMakerId", "dbo.PizzaMaker");
            DropForeignKey("dbo.PizzaToOrder", "PizzaId", "dbo.Pizza");
            DropIndex("dbo.ProductToPizza", new[] { "ProductId" });
            DropIndex("dbo.ProductToPizza", new[] { "PizzaId" });
            DropIndex("dbo.Pizza", new[] { "PizzaMakerId" });
            DropIndex("dbo.PizzaToOrder", new[] { "OrderId" });
            DropIndex("dbo.PizzaToOrder", new[] { "PizzaId" });
            DropTable("dbo.Product");
            DropTable("dbo.ProductToPizza");
            DropTable("dbo.PizzaMaker");
            DropTable("dbo.Pizza");
            DropTable("dbo.PizzaToOrder");
            DropTable("dbo.Order");
        }
    }
}

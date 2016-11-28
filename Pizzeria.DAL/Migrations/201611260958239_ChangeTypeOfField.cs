namespace Pizzeria.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeOfField : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PizzaToOrder", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Cart", "PizzaId", "dbo.Pizza");
            DropForeignKey("dbo.PizzaToOrder", "PizzaId", "dbo.Pizza");
            DropForeignKey("dbo.ProductToPizza", "PizzaId", "dbo.Pizza");
            DropForeignKey("dbo.Pizza", "PizzaMakerId", "dbo.PizzaMaker");
            DropForeignKey("dbo.ProductToPizza", "ProductId", "dbo.Product");
            DropIndex("dbo.PizzaToOrder", new[] { "PizzaId" });
            DropIndex("dbo.PizzaToOrder", new[] { "OrderId" });
            DropIndex("dbo.Pizza", new[] { "PizzaMakerId" });
            DropIndex("dbo.Cart", new[] { "PizzaId" });
            DropIndex("dbo.ProductToPizza", new[] { "PizzaId" });
            DropIndex("dbo.ProductToPizza", new[] { "ProductId" });
            DropPrimaryKey("dbo.Order");
            DropPrimaryKey("dbo.PizzaToOrder");
            DropPrimaryKey("dbo.Pizza");
            DropPrimaryKey("dbo.Cart");
            DropPrimaryKey("dbo.PizzaMaker");
            DropPrimaryKey("dbo.ProductToPizza");
            DropPrimaryKey("dbo.Product");
            AlterColumn("dbo.Order", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PizzaToOrder", "PizzaId", c => c.Int(nullable: false));
            AlterColumn("dbo.PizzaToOrder", "OrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.PizzaToOrder", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.Pizza", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Pizza", "PizzaMakerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cart", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Cart", "PizzaId", c => c.Int(nullable: false));
            AlterColumn("dbo.PizzaMaker", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ProductToPizza", "PizzaId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductToPizza", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Product", "Count", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Order", "Id");
            AddPrimaryKey("dbo.PizzaToOrder", new[] { "PizzaId", "OrderId" });
            AddPrimaryKey("dbo.Pizza", "Id");
            AddPrimaryKey("dbo.Cart", "Id");
            AddPrimaryKey("dbo.PizzaMaker", "Id");
            AddPrimaryKey("dbo.ProductToPizza", new[] { "PizzaId", "ProductId" });
            AddPrimaryKey("dbo.Product", "Id");
            CreateIndex("dbo.Cart", "PizzaId");
            CreateIndex("dbo.Pizza", "PizzaMakerId");
            CreateIndex("dbo.PizzaToOrder", "PizzaId");
            CreateIndex("dbo.PizzaToOrder", "OrderId");
            CreateIndex("dbo.ProductToPizza", "PizzaId");
            CreateIndex("dbo.ProductToPizza", "ProductId");
            AddForeignKey("dbo.PizzaToOrder", "OrderId", "dbo.Order", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PizzaToOrder", "PizzaId", "dbo.Pizza", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductToPizza", "PizzaId", "dbo.Pizza", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cart", "PizzaId", "dbo.Pizza", "Id");
            AddForeignKey("dbo.Pizza", "PizzaMakerId", "dbo.PizzaMaker", "Id");
            AddForeignKey("dbo.ProductToPizza", "ProductId", "dbo.Product", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductToPizza", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Pizza", "PizzaMakerId", "dbo.PizzaMaker");
            DropForeignKey("dbo.Cart", "PizzaId", "dbo.Pizza");
            DropForeignKey("dbo.ProductToPizza", "PizzaId", "dbo.Pizza");
            DropForeignKey("dbo.PizzaToOrder", "PizzaId", "dbo.Pizza");
            DropForeignKey("dbo.PizzaToOrder", "OrderId", "dbo.Order");
            DropIndex("dbo.ProductToPizza", new[] { "ProductId" });
            DropIndex("dbo.ProductToPizza", new[] { "PizzaId" });
            DropIndex("dbo.PizzaToOrder", new[] { "OrderId" });
            DropIndex("dbo.PizzaToOrder", new[] { "PizzaId" });
            DropIndex("dbo.Pizza", new[] { "PizzaMakerId" });
            DropIndex("dbo.Cart", new[] { "PizzaId" });
            DropPrimaryKey("dbo.Product");
            DropPrimaryKey("dbo.ProductToPizza");
            DropPrimaryKey("dbo.PizzaMaker");
            DropPrimaryKey("dbo.Cart");
            DropPrimaryKey("dbo.Pizza");
            DropPrimaryKey("dbo.PizzaToOrder");
            DropPrimaryKey("dbo.Order");
            AlterColumn("dbo.Product", "Count", c => c.Long(nullable: false));
            AlterColumn("dbo.Product", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.ProductToPizza", "ProductId", c => c.Long(nullable: false));
            AlterColumn("dbo.ProductToPizza", "PizzaId", c => c.Long(nullable: false));
            AlterColumn("dbo.PizzaMaker", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Cart", "PizzaId", c => c.Long(nullable: false));
            AlterColumn("dbo.Cart", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Pizza", "PizzaMakerId", c => c.Long(nullable: false));
            AlterColumn("dbo.Pizza", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.PizzaToOrder", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PizzaToOrder", "OrderId", c => c.Long(nullable: false));
            AlterColumn("dbo.PizzaToOrder", "PizzaId", c => c.Long(nullable: false));
            AlterColumn("dbo.Order", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Product", "Id");
            AddPrimaryKey("dbo.ProductToPizza", new[] { "PizzaId", "ProductId" });
            AddPrimaryKey("dbo.PizzaMaker", "Id");
            AddPrimaryKey("dbo.Cart", "Id");
            AddPrimaryKey("dbo.Pizza", "Id");
            AddPrimaryKey("dbo.PizzaToOrder", new[] { "PizzaId", "OrderId" });
            AddPrimaryKey("dbo.Order", "Id");
            CreateIndex("dbo.ProductToPizza", "ProductId");
            CreateIndex("dbo.ProductToPizza", "PizzaId");
            CreateIndex("dbo.Cart", "PizzaId");
            CreateIndex("dbo.Pizza", "PizzaMakerId");
            CreateIndex("dbo.PizzaToOrder", "OrderId");
            CreateIndex("dbo.PizzaToOrder", "PizzaId");
            AddForeignKey("dbo.ProductToPizza", "ProductId", "dbo.Product", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pizza", "PizzaMakerId", "dbo.PizzaMaker", "Id");
            AddForeignKey("dbo.ProductToPizza", "PizzaId", "dbo.Pizza", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PizzaToOrder", "PizzaId", "dbo.Pizza", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cart", "PizzaId", "dbo.Pizza", "Id");
            AddForeignKey("dbo.PizzaToOrder", "OrderId", "dbo.Order", "Id", cascadeDelete: true);
        }
    }
}

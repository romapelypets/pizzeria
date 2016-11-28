namespace Pizzeria.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFieldInPizzaToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PizzaToOrder", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.PizzaToOrder", "TimeAll");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PizzaToOrder", "TimeAll", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.PizzaToOrder", "UnitPrice");
        }
    }
}

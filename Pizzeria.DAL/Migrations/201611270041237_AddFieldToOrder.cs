namespace Pizzeria.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Order", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Order", "Phone", c => c.String(nullable: false));
            AddColumn("dbo.Order", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "Email");
            DropColumn("dbo.Order", "Phone");
            DropColumn("dbo.Order", "LastName");
            DropColumn("dbo.Order", "FirstName");
        }
    }
}

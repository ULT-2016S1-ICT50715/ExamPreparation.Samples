namespace PizzaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pizzas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Size_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sizes", t => t.Size_Id, cascadeDelete: true)
                .Index(t => t.Size_Id);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Toppings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ToppingPizzas",
                c => new
                    {
                        Topping_Id = c.Int(nullable: false),
                        Pizza_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Topping_Id, t.Pizza_Id })
                .ForeignKey("dbo.Toppings", t => t.Topping_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pizzas", t => t.Pizza_Id, cascadeDelete: true)
                .Index(t => t.Topping_Id)
                .Index(t => t.Pizza_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToppingPizzas", "Pizza_Id", "dbo.Pizzas");
            DropForeignKey("dbo.ToppingPizzas", "Topping_Id", "dbo.Toppings");
            DropForeignKey("dbo.Pizzas", "Size_Id", "dbo.Sizes");
            DropIndex("dbo.ToppingPizzas", new[] { "Pizza_Id" });
            DropIndex("dbo.ToppingPizzas", new[] { "Topping_Id" });
            DropIndex("dbo.Pizzas", new[] { "Size_Id" });
            DropTable("dbo.ToppingPizzas");
            DropTable("dbo.Toppings");
            DropTable("dbo.Sizes");
            DropTable("dbo.Pizzas");
        }
    }
}

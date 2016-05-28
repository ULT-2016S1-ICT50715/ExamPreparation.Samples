namespace PizzaApp.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PizzaApp.Models.PizzaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PizzaApp.Models.PizzaDbContext context)
        {
            context.Sizes.AddOrUpdate(
              s => s.Description,
              new Size { Description = "Small", Price = 12.5m },
              new Size { Description = "Medium", Price = 16m },
              new Size { Description = "Familiar", Price = 21m }
            );
        }
    }
}

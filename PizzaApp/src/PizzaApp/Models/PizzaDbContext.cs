using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.Models
{
    public class PizzaDbContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Size> Sizes { get; set; }
        
    }
}

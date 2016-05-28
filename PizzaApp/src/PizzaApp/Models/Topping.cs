using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.Models
{
    public class Topping
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public Topping()
        {
            Pizzas = new List<Pizza>();
        }
    }
}

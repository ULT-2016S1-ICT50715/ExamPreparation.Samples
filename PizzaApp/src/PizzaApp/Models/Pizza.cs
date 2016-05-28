using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public Size Size { get; set; }
        public List<Topping> Toppings { get; set; }

        public Pizza()
        {
            Toppings = new List<Topping>();
        }
    }
}

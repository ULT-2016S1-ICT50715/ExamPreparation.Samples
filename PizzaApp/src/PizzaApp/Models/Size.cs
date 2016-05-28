using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.Models
{
    public class Size
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}

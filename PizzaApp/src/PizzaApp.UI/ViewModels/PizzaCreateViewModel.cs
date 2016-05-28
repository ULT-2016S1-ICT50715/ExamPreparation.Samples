using PizzaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaApp.UI.ViewModels
{
    public class PizzaCreateViewModel
    {
        public string Name { get; set; }
        public int SizeId { get; set; }
        public SelectList Sizes { get; set; }
        public List<Topping> Toppings { get; set; }

    }
}
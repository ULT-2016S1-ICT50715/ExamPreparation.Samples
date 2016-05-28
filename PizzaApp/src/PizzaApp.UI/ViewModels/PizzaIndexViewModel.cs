using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaApp.UI.ViewModels
{
    public class PizzaIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Price { get; set; }
    }
}
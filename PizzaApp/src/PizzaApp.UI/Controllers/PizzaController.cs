using PizzaApp.Models;
using PizzaApp.Services;
using PizzaApp.UI.ViewModels;
using SharpRepository.EfRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaApp.UI.Controllers
{
    public class PizzaController : Controller
    {
        private PizzaDbContext _context;
        private PizzaAppService _pizzaService;
        private EfRepository<Pizza> _pizzaRepo;

        public PizzaController()
        {
            _context = new PizzaDbContext();
            _pizzaRepo = new EfRepository<Pizza>(_context);
            _pizzaService = new PizzaAppService(_pizzaRepo);

        }
        // GET: Pizza
        public ActionResult Index()
        {
            var pizzas = _context.Pizzas.Include(p => p.Toppings).Include(p => p.Size).ToList().Select(p => new PizzaIndexViewModel()
            {
                Name = p.Name,
                Price = p.Toppings.Sum(t => t.Price) + p.Size.Price,
                Size = p.Size.Description
            });
            return View(pizzas);
        }

        public ActionResult Create()
        {
            var pizza = new PizzaCreateViewModel();
            pizza.Sizes = new SelectList(_context.Sizes, "Id", "Description");
            return View(pizza);
        }
        [HttpPost]
        public ActionResult Create(PizzaCreateViewModel model)
        {
            //Creating some harcoded toppings
            var toppings = new List<Topping>()
            {
                new Topping() {Name="Cheddar Cheese",Price=3.5m },
                new Topping() {Name="Avocado",Price=3m },
            };

            if (ModelState.IsValid)
            {
                var size = _context.Sizes.Find(model.SizeId);
                _pizzaService.Create(model.Name, size, toppings);
                return RedirectToAction("Index");
            }
            model.Sizes = new SelectList(_context.Sizes, "Id", "Description");
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
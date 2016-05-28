using PizzaApp.Models;
using SharpRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.Services
{
    public class PizzaAppService
    {
        private IRepository<Pizza> _repo;
        public PizzaAppService(IRepository<Pizza> repo)
        {
            _repo = repo;
        }
        public Pizza Create(string name, Size size, List<Topping> toppings)
        {
            var pizza = new Pizza()
            {
                Name = name,
                Size = size,
                Toppings = toppings
            };
            _repo.Add(pizza);
            return pizza;
        }
        public Pizza Update(int id, string name, Size size, List<Topping> toppings)
        {
            var pizza = _repo.Get(id);
            if (pizza == null)
            {
                throw new ArgumentException(string.Format("No pizza found with id: {0}", id));
            }
            pizza.Name = name;
            pizza.Size = size;
            pizza.Toppings = toppings;
            _repo.Update(pizza);
            return pizza;
        }

        public List<Pizza> getAll()
        {
            return _repo.GetAll().ToList();
        }
    }
}

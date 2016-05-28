using PizzaApp.Models;
using PizzaApp.Services;
using SharpRepository.InMemoryRepository;
using System;
using System.Collections.Generic;
using Xunit;

namespace PizzaApp.Tests
{
    public class PizzaServiceTests
    {
        [Fact]
        public void TestCreate_ShouldReturnValidPizzaObject()
        {
            // Setup Fixture            
            var _pizzaRepo = new InMemoryRepository<Pizza>();
            var _sizeRepo = new InMemoryRepository<Size>();
            _sizeRepo.Add(new Size() { Description = "Familiar", Price = 21m });

            var _pizzaService = new PizzaAppService(_pizzaRepo);

            var expected = new Pizza()
            {
                Id = 1,
                Name = "Big Ozzi",
                Size = _sizeRepo.Get(1),
                Toppings = new List<Topping>() { new Topping { Name = "Cheese", Price = 3.5m } }
            };

            // Execute SUT

            var actual = _pizzaService.Create(expected.Name, expected.Size, expected.Toppings);

            // Verify Outcomes

            Assert.Equal(1, _pizzaRepo.Count());
            ArePizzasSame(expected, actual);
        }

        [Fact]
        public void TestUpdate_ShouldThrowExceptionForInvalidPizzaId()
        {
            // Setup Fixture
            var pizza = new Pizza();
            var _pizzaRepo = new InMemoryRepository<Pizza>();
            _pizzaRepo.Add(pizza);
            var _pizzaService = new PizzaAppService(_pizzaRepo);

            var invalidPizzaId = 3;

            // Execute SUT
            Assert.Throws<ArgumentException>(() => _pizzaService.Update(invalidPizzaId, null, null, null));
        }
        [Fact]
        public void TestUpdate_ShouldReturnUpdatedPizzaObjectFromRepo()
        {
            // Setup Fixture            
            var _pizzaRepo = new InMemoryRepository<Pizza>();
            var _sizeRepo = new InMemoryRepository<Size>();
            _sizeRepo.Add(new Size() { Description = "Familiar", Price = 21m });
            _sizeRepo.Add(new Size() { Description = "Personal", Price = 12m });

            var pizza = new Pizza()
            {
                Id = 1,
                Name = "Big Ozzi",
                Size = _sizeRepo.Get(1),
                Toppings = new List<Topping>() { new Topping { Name = "Cheese", Price = 3.5m } }
            };
            _pizzaRepo.Add(pizza);
            var _pizzaService = new PizzaAppService(_pizzaRepo);

            var expected = new Pizza()
            {
                Id = 1,
                Name = "Mighty Hawaian",
                Size = _sizeRepo.Get(2),
                Toppings = new List<Topping>() { new Topping { Name = "Cheddar Cheese", Price = 4.5m } }
            };
            // Execute SUT

            _pizzaService.Update(expected.Id, expected.Name, expected.Size, expected.Toppings);

            var actual = _pizzaRepo.Get(expected.Id);

            // Verify Outcomes

            ArePizzasSame(expected, actual);
        }

        private void ArePizzasSame(Pizza expected, Pizza actual)
        {
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Size, actual.Size);
            Assert.Equal(expected.Toppings, actual.Toppings);
        }
    }
}

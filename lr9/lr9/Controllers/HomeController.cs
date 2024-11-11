using Microsoft.AspNetCore.Mvc;
using lr9.Models;
using System.Collections.Generic;

namespace lr9.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Створення списку продуктів
            var products = new List<Product>
            {
                new Product { ID = 1, Name = "Product A", Price = 50.5m },
                new Product { ID = 2, Name = "Product B", Price = 75.0m },
                new Product { ID = 3, Name = "Product C", Price = 100.0m }
            };

            // Передача списку продуктів у представлення
            return View(products);
        }
    }
}

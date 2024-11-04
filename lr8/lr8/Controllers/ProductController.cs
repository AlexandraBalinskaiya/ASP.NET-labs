using Microsoft.AspNetCore.Mvc;
using lr8.Models;

namespace lr8.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { ID = 1, Name = "Product A", Price = 50.5m, CreatedDate = DateTime.Now.AddDays(-10) },
                new Product { ID = 2, Name = "Product B", Price = 75.0m, CreatedDate = DateTime.Now.AddDays(-20) },
                new Product { ID = 3, Name = "Product C", Price = 100.0m, CreatedDate = DateTime.Now.AddDays(-5) }
            };

            return View(products);
        }
    }
}

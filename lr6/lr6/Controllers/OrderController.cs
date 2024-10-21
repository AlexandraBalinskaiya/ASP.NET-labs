using lr6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace lr6.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Register()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (user.Age > 16)
            {
                return RedirectToAction("SelectProducts");
            }

            ViewBag.Message = "Возраст должен быть больше 16 лет!";
            return View(user);
        }

        public IActionResult SelectProducts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SelectProducts(int numberOfProducts)
        {
            if (numberOfProducts > 0)
            {
                var products = new List<Product>();
                for (int i = 0; i < numberOfProducts; i++)
                {
                    products.Add(new Product());
                }
                // Зберігаємо список продуктів в сесію
                HttpContext.Session.Set("Products", products);
                return View("FillProducts", products);
            }
            return View();
        }

        [HttpPost]
        public IActionResult FillProducts(List<Product> products)
        {
            // Оновлюємо продукти в сесії
            HttpContext.Session.Set("Products", products);
            return RedirectToAction("Summary");
        }

        public IActionResult Summary()
        {
            // Отримуємо продукти з сесії
            var products = HttpContext.Session.Get<List<Product>>("Products");
            return View(products);
        }
    }
}

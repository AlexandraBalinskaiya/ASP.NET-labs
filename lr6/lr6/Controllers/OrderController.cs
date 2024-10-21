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

<<<<<<< HEAD
            ViewBag.Message = "Возраст должен быть больше 16 лет!";
=======
            ViewBag.Message = "Вік має бути більше 16 років!";
>>>>>>> 6c6b3a9b697328b5b0acec3a8941f3ea97708b80
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

<<<<<<< HEAD
        public IActionResult Summary()
=======
        public IActionResult Summary(List<Product> products)
>>>>>>> 6c6b3a9b697328b5b0acec3a8941f3ea97708b80
        {
            // Отримуємо продукти з сесії
            var products = HttpContext.Session.Get<List<Product>>("Products");
            return View(products);
        }
    }
}

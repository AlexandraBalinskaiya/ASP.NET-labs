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

            ViewBag.Message = "Вік має бути більше 16 років!";
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
                return View("FillProducts", products);
            }
            return View();
        }

        [HttpPost]
        public IActionResult FillProducts(List<Product> products)
        {
            return RedirectToAction("Summary", new { products = products });
        }

        public IActionResult Summary(List<Product> products)
        {
            return View(products);
        }
    }
}

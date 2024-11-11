using Microsoft.AspNetCore.Mvc;
using System;

namespace lr5.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveToCookies(string value, DateTime expiryDate)
        {
            var options = new CookieOptions
            {
                Expires = expiryDate
            };
            Response.Cookies.Append("UserValue", value, options);
            return RedirectToAction("CheckCookies");
        }
        
        public IActionResult CheckCookies()
        {
            return View();
        }
        [HttpGet]
        public IActionResult TriggerError()
        {
            throw new Exception("Test exception to log error");
        }
    }
}

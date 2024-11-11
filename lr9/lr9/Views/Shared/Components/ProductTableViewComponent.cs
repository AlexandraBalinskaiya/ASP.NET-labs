using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using lr9.Models;

namespace lr9.Views.Shared.Components
{
    public class ProductTableViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<Product> products)
        {
            return View(products);
        }
    }
}

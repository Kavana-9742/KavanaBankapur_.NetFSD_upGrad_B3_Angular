using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
namespace WebApplication2.Controllers
{
    public class ProdController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = new List<Product>
            {
                new Product { PId = 1, PName = "Laptop", Category = "electronics", Price = 60000},
                new Product { PId = 2, PName = "Mobile", Category = "electronics", Price = 20000},
                new Product { PId = 3, PName = "Keyboard", Category = "electronics", Price = 5000},
                new Product { PId = 4, PName = "Table", Category = "Furniture", Price = 20000},
                new Product { PId = 5, PName = "Mouse", Category = "electronics", Price = 2000}
            };
            return View(products);
        }

        public IActionResult Details()
        {
            Product prodObj = new Product()
            {
                PId = 101,
                PName = "Chair",
                Category = "Furniture",
                Price = 35000
            };
            return View(prodObj);
        }
    }
}

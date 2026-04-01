using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> products = new List<Product>()
        {
            new Product{ProductId = 1, ProductName = "Laptop", Price = 60000, Category = "Electronics"},
            new Product{ProductId = 2, ProductName = "Mobile", Price = 45000, Category = "Electronics"},
            new Product{ProductId = 3, ProductName = "Keyboard", Price = 20000, Category = "Electronics"},
            new Product{ProductId = 4, ProductName = "Mouse", Price = 2000, Category = "Electronics"},
        };
        public IActionResult Index()
        {
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                products.Add(p);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                var product = products.FirstOrDefault(x => x.ProductId == p.ProductId);
                product.ProductName = p.ProductName;
                product.Price = p.Price;
                product.Category = p.Category;

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);
            products.Remove(product);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);
            return View(product);
        }
    }
}

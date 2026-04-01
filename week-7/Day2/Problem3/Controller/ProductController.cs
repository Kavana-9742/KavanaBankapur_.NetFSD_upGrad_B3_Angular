using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication5.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>();

        [HttpGet("Index")]
        public IActionResult Index()
        {
            ViewBag.Products = products;
            return View();
        }

        [HttpPost("Add")]
        public IActionResult Add(string name, decimal price, int quantity)
        {
            Product p = new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity
            };
            products.Add(p);
            ViewBag.Products = products;
            return View("Index");
        }
    }
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

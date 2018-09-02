using LearningEFCore.Interfaces;
using LearningEFCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningEFCore.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository repository;

        public HomeController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index(string category = null, decimal? price = null, bool includeRelated = true)
        {
            var products = this.repository.GetFilteredProducts(category, price, includeRelated);

            ViewBag.category = category;
            ViewBag.price = price;
            ViewBag.includeRelated = includeRelated;

            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.CreateMode = true;
            return View("Edit", new Product());
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            this.repository.CreateProduct(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(long id)
        {
            ViewBag.CreateMode = false;
            return View("Edit", this.repository.GetProduct(id));
        }

        [HttpPost]
        public IActionResult Edit(Product product, Product original)
        {
            this.repository.UpdateProduct(product, original);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(long id)
        {
            return View("Details", this.repository.GetProduct(id));
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            this.repository.DeleteProduct(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

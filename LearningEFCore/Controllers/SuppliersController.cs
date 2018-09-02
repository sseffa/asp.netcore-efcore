using LearningEFCore.Data;
using LearningEFCore.Interfaces;
using LearningEFCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LearningEFCore.Controllers
{
    public class SuppliersController : Controller
    {
        private ISupplierRepository supplierRepository;
        private DataContext dbContext;

        public SuppliersController(ISupplierRepository supplierRepo, DataContext context)
        {
            supplierRepository = supplierRepo;
            dbContext = context;
        }

        public IActionResult Index()
        {
            ViewBag.SupplierEditId = TempData["SupplierEditId"];
            ViewBag.SupplierCreateId = TempData["SupplierCreateId"];
            ViewBag.SupplierRelationshipId = TempData["SupplierRelationshipId"];

            return View(supplierRepository.GetAll());
        }

        public IActionResult Edit(long id)
        {
            TempData["SupplierEditId"] = id;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Update(Supplier supplier)
        {
            supplierRepository.Update(supplier);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create(long id)
        {
            TempData["SupplierCreateId"] = id;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Change(long id)
        {
            TempData["SupplierRelationshipId"] = id;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Change(long Id, Product[] products)
        {
            dbContext.Products.UpdateRange(products.Where(p => p.SupplierId != Id));
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
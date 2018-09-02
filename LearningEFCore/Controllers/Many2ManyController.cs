using LearningEFCore.Data;
using LearningEFCore.Models;
using LearningEFCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LearningEFCore.Controllers
{
    public class Many2ManyController : Controller
    {
        private DataContext context;

        public Many2ManyController(DataContext ctx) => context = ctx;

        public IActionResult Index()
        {
            return View(new ProductShipmentViewModel
            {
                Products = context.Products.Include(p => p.ProductShipments)
                    .ThenInclude(ps => ps.Shipment).ToArray(),
                Shipments = context.Set<Shipment>().Include(s => s.ProductShipments)
                    .ThenInclude(ps => ps.Product).ToArray()
            });
        }

        public IActionResult EditShipment(long id)
        {
            ViewBag.Products = context.Products.Include(p => p.ProductShipments);
            return View("Edit", context.Set<Shipment>().Find(id));
        }

        public IActionResult UpdateShipment(long id, long[] pids)
        {
            Shipment shipment = context.Set<Shipment>()
                .Include(s => s.ProductShipments).First(s => s.Id == id);
            shipment.ProductShipments = pids.Select(pid
                => new ProductShipmentJunction
                {
                    ShipmentId = id,
                    ProductId = pid
                }).ToList();
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
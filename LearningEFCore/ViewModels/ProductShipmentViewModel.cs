using LearningEFCore.Models;
using System.Collections.Generic;

namespace LearningEFCore.ViewModels
{
    public class ProductShipmentViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Shipment> Shipments { get; set; }
    }
}

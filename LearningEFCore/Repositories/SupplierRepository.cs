using LearningEFCore.Data;
using LearningEFCore.Interfaces;
using LearningEFCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LearningEFCore.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private DataContext context;

        public SupplierRepository(DataContext ctx) => context = ctx;

        public Supplier Get(long id)
        {
            return context.Suppliers.Find(id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return context.Suppliers.Include(p => p.Products);
        }

        public void Create(Supplier newDataObject)
        {
            context.Add(newDataObject);
            context.SaveChanges();
        }

        public void Update(Supplier changedDataObject)
        {
            context.Update(changedDataObject);
            context.SaveChanges();
        }

        public void Delete(long id)
        {
            context.Remove(Get(id));
            context.SaveChanges();
        }
    }
}

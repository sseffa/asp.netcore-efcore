using LearningEFCore.Models;
using System.Collections.Generic;

namespace LearningEFCore.Interfaces
{
    public interface ISupplierRepository
    { 
        Supplier Get(long id);
        IEnumerable<Supplier> GetAll();
        void Create(Supplier newDataObject);
        void Update(Supplier changedDataObject);
        void Delete(long id);
    }
}

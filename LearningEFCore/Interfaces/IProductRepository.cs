using LearningEFCore.Models;
using System.Collections.Generic;

namespace LearningEFCore.Interfaces
{
    public interface IProductRepository
    {
        Product GetProduct(long id);

        IEnumerable<Product> GetAllProducts();

        IEnumerable<Product> GetFilteredProducts(string category = null,
           decimal? price = null, bool includeRelated = true);

        void CreateProduct(Product newProduct);

        void UpdateProduct(Product changedProduct,
            Product originalProduct = null);

        void DeleteProduct(long id);
    }
}

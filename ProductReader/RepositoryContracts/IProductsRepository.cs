using Catalog.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.RepositoryContracts
{
    public interface IProductsRepository
    {
        List<Product> FindNewProducts();

        Task<List<Product>> GetAll();

        Task SaveProducts(List<Product> productsToSave);

        Task SaveChangesAsync();
    }
}

using Catalog.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.RepositoryContracts
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAll();

        Task SaveProducts(List<Product> productsToSave);

        Task SaveChangesAsync();
    }
}

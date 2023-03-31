using ProductReader.Products;
using System.Collections.Generic;

namespace ProductReader.RepositoryContracts
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
    }
}

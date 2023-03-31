using Microsoft.Extensions.Logging;
using Catalog.RepositoryContracts;
using System.Threading.Tasks;

namespace Catalog.Products
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IProductsRepository _productsRepository;

        public ProductService(ILogger<ProductService> logger, IProductsRepository productsRepository)
        {
            _logger = logger;
            _productsRepository = productsRepository;
        }

        public async Task UpdateProductsCatalog()
        {
            _logger.LogInformation("Updating products catalog");

            var products = await _productsRepository.GetAll();
            await _productsRepository.SaveProducts(products);
            await _productsRepository.SaveChangesAsync();
        }
    }
}

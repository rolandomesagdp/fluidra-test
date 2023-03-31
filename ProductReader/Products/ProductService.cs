using Microsoft.Extensions.Logging;
using ProductReader.RepositoryContracts;
using System.Threading.Tasks;

namespace ProductReader.Products
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
            await Task.Run(() =>
            {
                _logger.LogInformation("Updating products catalog");
                _productsRepository.GetAll();
            });
        }
    }
}

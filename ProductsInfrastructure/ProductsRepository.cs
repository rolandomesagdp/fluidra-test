using Microsoft.Extensions.Logging;
using ProductReader.Products;
using ProductReader.RepositoryContracts;
using ProductsInfrastructure.Files;
using ProductsInfrastructure.ProductFileMappingStrategies;
using System.Collections.Generic;
using System.Linq;

namespace ProductsInfrastructure
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ILogger<ProductsRepository> _logger;

        public ProductsRepository(ILogger<ProductsRepository> logger)
        {
            _logger = logger;
        }

        public List<Product> GetAll()
        {
            var products = new List<Product>();
            _logger.LogInformation("Start reading products from files");
            var filesReader = new FtpFileReader();
            var files = filesReader.GetAllFiles();

            products = files.Select(x => x.AsProduct()).ToList();

            return products;
        }
    }
}

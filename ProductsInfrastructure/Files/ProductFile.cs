using Microsoft.Extensions.Logging;
using ProductReader.Products;
using ProductsInfrastructure.ProductFileMappingStrategies;

namespace ProductsInfrastructure.Files
{
    internal class ProductFile
    {
        private readonly ILogger _logger;

        public string FileName { get; set; }

        public FileExtensions FileExtension { get; set; }

        public ProductFile(ILogger logger)
        {
            _logger = logger;
        }

        public Product AsProduct()
        {
            var mapper = new FileToProductMapper(_logger, this);
            var product = mapper.Map();
            return product;
        }
    }
}

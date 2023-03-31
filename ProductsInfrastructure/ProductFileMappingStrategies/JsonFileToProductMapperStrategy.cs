using Microsoft.Extensions.Logging;
using ProductReader.Products;
using ProductsInfrastructure.Files;
using ProductsInfrastructure.ProductFileParser;
using System.Collections.Generic;

namespace ProductsInfrastructure.ProductFileMapper
{
    internal class JsonFileToProductMapperStrategy : IFileToProductMappingStrategy
    {
        private readonly ILogger _logger;

        public JsonFileToProductMapperStrategy(ILogger logger)
        {
            _logger = logger;
        }
        public Product MapFileToProduct(ProductFile file)
        {
            _logger.LogInformation("Maping products from Json file");
            return new Product();
        }
    }
}

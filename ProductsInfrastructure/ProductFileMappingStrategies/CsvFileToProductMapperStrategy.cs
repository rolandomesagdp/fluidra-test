﻿using Microsoft.Extensions.Logging;
using ProductReader.Products;
using ProductsInfrastructure.Files;
using ProductsInfrastructure.ProductFileParser;

namespace ProductsInfrastructure.ProductFileMapper
{
    internal class CsvFileToProductMapperStrategy : IFileToProductMappingStrategy
    {
        private readonly ILogger _logger;

        public CsvFileToProductMapperStrategy(ILogger logger)
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
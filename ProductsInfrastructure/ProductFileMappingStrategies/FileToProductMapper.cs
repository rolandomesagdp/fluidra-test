using Microsoft.Extensions.Logging;
using ProductReader.Products;
using ProductsInfrastructure.Files;
using ProductsInfrastructure.ProductFileMapper;
using ProductsInfrastructure.ProductFileParser;
using System.Collections.Generic;

namespace ProductsInfrastructure.ProductFileMappingStrategies
{
    internal class FileToProductMapper
    {
        private readonly ILogger _logger;
        private IFileToProductMappingStrategy _mappingStrategy;

        public ProductFile File { get; private set; }

        public FileToProductMapper(ILogger logger, ProductFile productFile)
        {
            _logger = logger;
            File = productFile;
        }

        public Product Map()
        {
            _logger.LogInformation("Starting file to product mapping process");
            SetMappingStrategy();
            return _mappingStrategy.MapFileToProduct(File);
        }

        private void SetMappingStrategy()
        {
            switch (File.FileExtension)
            {
                case FileExtensions.Json:
                    _mappingStrategy = new JsonFileToProductMapperStrategy(_logger);
                    break;
                case FileExtensions.Csv:
                    _mappingStrategy = new CsvFileToProductMapperStrategy(_logger);
                    break;
                default:
                    break;
            }
        }
    }
}

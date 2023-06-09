﻿using Catalog.ProductFiles;
using Catalog.ProductFileMapper;
using Catalog.ProductFileParser;
using Catalog.Products;

namespace Catalog.ProductFileMappingStrategies
{
    internal class FileToProductMapper
    {
        private IFileToProductMappingStrategy _mappingStrategy;

        public ProductFile File { get; private set; }

        public FileToProductMapper(ProductFile productFile)
        {
            File = productFile;
        }

        public Product Map()
        {
            SetMappingStrategy();
            return _mappingStrategy.MapFileToProduct(File);
        }

        private void SetMappingStrategy()
        {
            switch (File.FileExtension)
            {
                case FileExtensions.Json:
                    _mappingStrategy = new JsonFileToProductMapperStrategy();
                    break;
                case FileExtensions.Csv:
                    _mappingStrategy = new CsvFileToProductMapperStrategy();
                    break;
                default:
                    break;
            }
        }
    }
}

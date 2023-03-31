using ProductReader.Products;
using ProductsInfrastructure.Files;
using System.Collections.Generic;

namespace ProductsInfrastructure.ProductFileParser
{
    internal interface IFileToProductMappingStrategy
    {
        Product MapFileToProduct(ProductFile file);
    }
}

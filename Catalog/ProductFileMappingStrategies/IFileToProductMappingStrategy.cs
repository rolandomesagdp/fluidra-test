using Catalog.ProductFiles;
using Catalog.Products;

namespace Catalog.ProductFileParser
{
    internal interface IFileToProductMappingStrategy
    {
        Product MapFileToProduct(ProductFile file);
    }
}

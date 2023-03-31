using Catalog.ProductFileMappingStrategies;
using Catalog.Products;

namespace Catalog.ProductFiles
{
    public class ProductFile
    {
        public string FileName { get; set; }

        public FileExtensions FileExtension { get; set; }

        public Product AsProduct()
        {
            var mapper = new FileToProductMapper(this);
            var product = mapper.Map();
            return product;
        }
    }
}

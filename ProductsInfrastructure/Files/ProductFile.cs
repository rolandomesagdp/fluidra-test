using ProductReader.Products;
using ProductsInfrastructure.ProductFileMappingStrategies;

namespace ProductsInfrastructure.Files
{
    internal class ProductFile
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

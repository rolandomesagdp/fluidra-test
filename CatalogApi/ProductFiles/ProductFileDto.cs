using Catalog.ProductFiles;

namespace CatalogApi.ProductFiles
{
    public class ProductFileDto
    {
        public string FileName { get; set; }

        public FileExtensions FileExtension { get; set; }
    }
}

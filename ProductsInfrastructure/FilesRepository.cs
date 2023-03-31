using Catalog.ProductFiles;
using Catalog.RepositoryContracts;
using System.Collections.Generic;

namespace CatalogInfrastructure
{
    public class FilesRepository : IFilesRepository
    {
        private readonly string ftpFilePath = "some/path/to/an/ftp/server";

        public List<ProductFile> GetFiles()
        {
            return new List<ProductFile>
            {
                new ProductFile { FileName = "CsvFile", FileExtension = FileExtensions.Csv },
                new ProductFile { FileName = "JsonFile", FileExtension= FileExtensions.Json },
            };
        }

        public void ClearFiles()
        {
            // Clear all files vía FTP
        }

        public void AddFile(ProductFile file)
        {
            // Add a file vía FTP
        }
    }
}

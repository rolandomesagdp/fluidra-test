using System.Collections.Generic;

namespace ProductsInfrastructure.Files
{
    internal class FtpFileReader
    {
        private readonly string ftpFilePath = "some/path/to/an/ftp/server";

        public List<ProductFile> GetAllFiles()
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

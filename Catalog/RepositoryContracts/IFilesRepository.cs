using Catalog.ProductFiles;
using System.Collections.Generic;

namespace Catalog.RepositoryContracts
{
    public interface IFilesRepository
    {
        List<ProductFile> GetFiles();

        void AddFile(ProductFile file);

        void ClearFiles();
    }
}

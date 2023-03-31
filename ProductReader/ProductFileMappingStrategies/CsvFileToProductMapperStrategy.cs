using Catalog.ProductFiles;
using Catalog.ProductFileParser;
using Catalog.Products;
using System;

namespace Catalog.ProductFileMapper
{
    internal class CsvFileToProductMapperStrategy : IFileToProductMappingStrategy
    {

        /// <summary>
        /// Here goes the logic for reading a csv file and map it to a Product entity
        /// The logic below dummy example for the sake of time. Im concentrated only in the architectural structure.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public Product MapFileToProduct(ProductFile file)
        {
            Console.WriteLine("Maping products from CSV file");
            
            return new Product { ProductName = file.FileName };
        }
    }
}

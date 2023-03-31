﻿using ProductReader.Products;
using ProductsInfrastructure.Files;
using ProductsInfrastructure.ProductFileParser;
using System;

namespace ProductsInfrastructure.ProductFileMapper
{
    internal class JsonFileToProductMapperStrategy : IFileToProductMappingStrategy
    {
        /// <summary>
        /// Here goes the logic for reading a json file and map it to a Product entity
        /// The logic below dummy example for the sake of time. Im concentrated only in the architectural structure.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public Product MapFileToProduct(ProductFile file)
        {
            Console.WriteLine("Maping products from Json file");
            return new Product { ProductName = file.FileName };
        }
    }
}

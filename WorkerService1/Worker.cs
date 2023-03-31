using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProductReader.Products;
using ProductReader.ReadAndRetry;
using ProductsInfrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataIngestion
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDoAndRetryService _doAndRetryService;
        private readonly IProductService _productService;
        private readonly ProductsContext _productsContext;

        public Worker(ILogger<Worker> logger, 
            IDoAndRetryService doAndRetryService, 
            IProductService productService,
            IDbContextFactory<ProductsContext> contextFactory)
        {
            _logger = logger;
            _doAndRetryService = doAndRetryService;
            _productService = productService;
            _productsContext = contextFactory.CreateDbContext();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Data ingestion worker starting...");
            await PopulateDb();
            while (!stoppingToken.IsCancellationRequested)
            {
                await _doAndRetryService.DoAndRetry(_productService.UpdateProductsCatalog);
                await Task.Delay(2000, stoppingToken);
            }
        }

        public async Task PopulateDb()
        {
            var productsList = new List<Product>
            {
                new Product { ProductName = "Product 1"},
                new Product { ProductName = "Product 2"},
                new Product { ProductName = "Product 3"},
                new Product { ProductName = "Product 4"}
            };
            await _productsContext.Products.AddRangeAsync(productsList);
            await _productsContext.SaveChangesAsync();

            _logger.LogInformation("DB populated");
        }
    }
}

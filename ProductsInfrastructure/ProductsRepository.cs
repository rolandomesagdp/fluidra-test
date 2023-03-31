using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductReader.Products;
using ProductReader.RepositoryContracts;
using ProductsInfrastructure.Files;
using ProductsInfrastructure.ProductFileMappingStrategies;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsInfrastructure
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ILogger<ProductsRepository> _logger;
        private readonly ProductsContext _context;

        public ProductsRepository(ILogger<ProductsRepository> logger, IDbContextFactory<ProductsContext> contextFactory)
        {
            _logger = logger;
            _context = contextFactory.CreateDbContext();
        }

        public List<Product> FindNewProducts()
        {
            var products = new List<Product>();
            _logger.LogInformation("Start reading products from files");
            var filesReader = new FtpFileReader();
            var files = filesReader.GetAllFiles();

            products = files.Select(x => x.AsProduct()).ToList();

            return products;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task SaveProducts(List<Product> productsToSave)
        {
            await _context.Products.AddRangeAsync(productsToSave);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

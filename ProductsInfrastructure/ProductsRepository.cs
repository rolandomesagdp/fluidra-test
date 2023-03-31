using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Catalog.Products;
using Catalog.RepositoryContracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogInfrastructure
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ILogger<ProductsRepository> _logger;
        private readonly CatalogContext _context;
        private readonly IFilesRepository _filesRepository;

        public ProductsRepository(ILogger<ProductsRepository> logger, IDbContextFactory<CatalogContext> contextFactory,
            IFilesRepository filesRepository)
        {
            _logger = logger;
            _context = contextFactory.CreateDbContext();
            _filesRepository = filesRepository;
        }

        public List<Product> FindNewProducts()
        {
            var products = new List<Product>();
            _logger.LogInformation("Start reading products from files");
            var files = _filesRepository.GetFiles();

            products = files.Select(x => x.AsProduct()).ToList();
            _filesRepository.ClearFiles();
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

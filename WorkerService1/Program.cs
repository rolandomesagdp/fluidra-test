using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductReader.Products;
using ProductReader.ReadAndRetry;
using ProductReader.RepositoryContracts;
using ProductsInfrastructure;

namespace DataIngestion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IProductsRepository, ProductsRepository>();
                    services.AddSingleton<IDoAndRetryService, DoAndRetryService>();
                    services.AddSingleton<IProductService, ProductService>();
                    services.AddHostedService<Worker>();

                    services.AddDbContextFactory<ProductsContext>(options =>
                    {
                        options.UseInMemoryDatabase("ProductDB")
                        .EnableSensitiveDataLogging()
                        .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                    });
                });
    }
}

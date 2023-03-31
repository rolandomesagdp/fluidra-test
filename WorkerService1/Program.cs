using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductReader.Products;
using ProductReader.ReadAndRetry;
using ProductReader.RepositoryContracts;
using ProductsInfrastructure;

namespace WorkerService1
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
                });
    }
}

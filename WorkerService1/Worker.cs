using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProductReader.Products;
using ProductReader.ReadAndRetry;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDoAndRetryService _readAndRetryService;
        private readonly IProductService _productService;

        public Worker(ILogger<Worker> logger, IDoAndRetryService readAndRetryService, IProductService productService)
        {
            _logger = logger;
            _readAndRetryService = readAndRetryService;
            _productService = productService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Data ingestion service starting...");
            while (!stoppingToken.IsCancellationRequested)
            {
                await _readAndRetryService.Do(_productService.UpdateProductsCatalog);
                await Task.Delay(1000, stoppingToken);
            }
        }

        private ILogger<DoAndRetryService> ReadingServiceLogger()
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Information);
                builder.AddConsole();
                builder.AddEventSourceLogger();
            });
            var logger = loggerFactory.CreateLogger<DoAndRetryService>();
            return logger;
        }
    }
}

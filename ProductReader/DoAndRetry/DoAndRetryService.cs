using Microsoft.Extensions.Logging;
using ProductReader.Products;
using System;
using System.Threading.Tasks;

namespace ProductReader.ReadAndRetry
{
    public class DoAndRetryService : IDoAndRetryService
    {
        private readonly ILogger<DoAndRetryService> _logger;
        private readonly IProductService _productService;

        /// <summary>
        /// This is the number of retries.
        /// In a real world app this value would come from appsettings.json.
        /// </summary>
        public int RetryCount { get; private set; } = 3;

        /// <summary>
        /// This is the Sleep time after an attemp fails.
        /// In a real world app this value would come from appsettings.json as a number of seconds.
        /// </summary>
        public TimeSpan SleepPeriod { get; private set; } = TimeSpan.FromSeconds(10);

        public DoAndRetryService(ILogger<DoAndRetryService> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        /// <summary>
        /// Here starts the reading process.
        /// </summary>
        public async Task Do(Func<Task> action)
        {
            _logger.LogInformation("Reading from files and storing the values...");
            await _productService.UpdateProductsCatalog();
        }
    }
}

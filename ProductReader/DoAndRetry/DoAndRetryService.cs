using Microsoft.Extensions.Logging;
using ProductReader.Products;
using System;
using System.Threading;
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
        public int MaximumAttempts { get; private set; } = 3;

        /// <summary>
        /// This is the Sleep time after an attemp fails.
        /// In a real world app this value would come from appsettings.json as a number of seconds.
        /// </summary>
        public TimeSpan SleepPeriod { get; private set; } = TimeSpan.FromSeconds(2);

        public DoAndRetryService(ILogger<DoAndRetryService> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        /// <summary>
        /// Generic retry logic.
        /// </summary>
        public async Task DoAndRetry(Func<Task> action)
        {
            var currentAttempt = 0;

            while (true)
            {
                currentAttempt++;
                try
                {
                    //TestRetry(currentAttempt);
                    await action();
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    if (currentAttempt == MaximumAttempts)
                    {
                        throw ex;
                    }
                    Thread.Sleep(SleepPeriod);
                }
            }
        }

        private void TestRetry(int currentAttempt)
        {
            if (currentAttempt < MaximumAttempts)
                throw new Exception("Forcing retry");
        }
    }
}

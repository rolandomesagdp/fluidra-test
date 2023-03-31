using System;
using System.Threading.Tasks;

namespace ProductReader.ReadAndRetry
{
    public interface IDoAndRetryService
    {
        int RetryCount { get; }

        TimeSpan SleepPeriod { get; }

        Task Do(Func<Task> action);
    }
}

using System;
using System.Threading.Tasks;

namespace Catalog.ReadAndRetry
{
    public interface IDoAndRetryService
    {
        int MaximumAttempts { get; }

        TimeSpan SleepPeriod { get; }

        Task DoAndRetry(Func<Task> action);
    }
}

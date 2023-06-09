﻿using System;
using System.Threading.Tasks;

namespace CatalogIngestionWorker.DoAndRetry
{
    public interface IDoAndRetryService
    {
        int MaximumAttempts { get; }

        TimeSpan SleepPeriod { get; }

        Task DoAndRetry(Func<Task> action);
    }
}
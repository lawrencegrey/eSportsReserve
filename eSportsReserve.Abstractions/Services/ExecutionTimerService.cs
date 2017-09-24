using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace eSportsReserve.Abstractions.Services
{
    public class ExecutionTimerService
    {
        private readonly ILogger _logger;
        private readonly Stopwatch _sw;

        public ExecutionTimerService(ILoggerFactory loggerFactory)
        {
            _sw = new Stopwatch();
            _sw.Start();
            _logger = loggerFactory.CreateLogger<ExecutionTimerService>();
        }

        public long RequestTime()
        {
            _sw.Stop();
            _logger.LogInformation($@"Request processed in {_sw.ElapsedMilliseconds}ms");
            return _sw.ElapsedMilliseconds;
        }
    }
}

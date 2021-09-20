using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using MyWorker.Contracts;

namespace MyWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ConfigurationDataContract _configurationDataContract;
        public Worker(ILogger<Worker> logger,
            ConfigurationDataContract configurationDataContract)
        {
            _logger = logger;
            _configurationDataContract = configurationDataContract;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _logger.LogInformation($"Configuration is {_configurationDataContract}");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

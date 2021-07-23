using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotNetDependencyInjection.examples._01
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger) =>
            _logger = logger;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("le worker se lance");
            int count = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                count++;
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                Console.WriteLine($"console: worker running loop {count}");
                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}
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
        private readonly IService _doSomethingService;

        public Worker(ILogger<Worker> logger, IService doSomethingService)
        {
            _logger = logger;
            _doSomethingService = doSomethingService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("le worker se lance");
            int count = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                count++;
                _doSomethingService.Process($"{count}");
                
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}
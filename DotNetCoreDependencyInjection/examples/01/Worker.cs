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
        private readonly IService _service;
        private readonly ISerializer _serializer;
        private readonly IConfigurationDisplayer _configurationDisplayer;

        public Worker(ILogger<Worker> logger, IService service, ISerializer serializer, IConfigurationDisplayer configurationDisplayer)
        {
            _logger = logger;
            _service = service;
            _serializer = serializer;
            _configurationDisplayer = configurationDisplayer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("le worker se lance");
            _logger.LogInformation("le worker se lance");
            int count = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                count++;
                _service.Do($"{count}");

                var serialization = _serializer.Serialize("message to serialize");
                
                _configurationDisplayer.Display();
                
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}
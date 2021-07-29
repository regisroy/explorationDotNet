using Microsoft.Extensions.Logging;

namespace DotNetDependencyInjection.examples._01
{
    public class DoSomethingService: IService
    {
        private readonly ILogger<IService> _logger;

        public DoSomethingService(ILogger<IService> logger)
        {
            _logger = logger;
        }

        public void Process(string message)
        {
            _logger.LogInformation($"--> DoSomethingService: {message})");
        }
    }
}
using Microsoft.Extensions.Logging;

namespace DotNetDependencyInjection.examples._01
{
    public interface IService
    {
        public void Do(string info);

        public void Before() {}

        public void After() {}
    }

    public class Service : IService
    {
        private readonly ILogger<Service> _logger;
        private readonly IRepository _repository;

        public Service(ILogger<Service> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public void Do(string info)
        {
            _logger.LogInformation("Do {}", info);
            _repository.GetInfos();
        }

        // public void Before()
        // {
        // }

        // public void After()
        // {
        // }
    }
}
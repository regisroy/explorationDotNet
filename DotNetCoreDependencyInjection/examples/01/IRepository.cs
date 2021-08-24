using Microsoft.Extensions.Logging;

namespace DotNetDependencyInjection.examples._01
{
    public interface IRepository
    {
        public string GetInfos();
    }

    class Repository : IRepository
    {
        private readonly ILogger<Repository> _logger;
        private readonly IDatabase _database;
        private int _counter = 1;

        public Repository(ILogger<Repository> logger, IDatabase database)
        {
            _logger = logger;
            _database = database;
        }

        public string GetInfos()
        {
            _database.Connect();
            _database.Select("my query");
            _logger.LogInformation("GetInfos {}", _counter);
            return "infos repository " + _counter++;
        }
    }
}
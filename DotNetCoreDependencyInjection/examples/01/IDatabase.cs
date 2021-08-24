using Microsoft.Extensions.Logging;

namespace DotNetDependencyInjection.examples._01
{
    interface IDatabase
    {
        public void Connect();
        string Select(string query);
    }

    class Database : IDatabase
    {
        private readonly ILogger<Database> _logger;

        public Database(ILogger<Database> logger)
        {
            _logger = logger;
        }

        public void Connect()
        {
            _logger.LogInformation("Database.Connect");
        }

        public string Select(string query)
        {
            _logger.LogInformation("Database.Select {0}", query);
            return "select OK";
        }
    }
}
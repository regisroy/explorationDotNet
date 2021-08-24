using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DotNetDependencyInjection.examples._01
{
    public interface IConfigurationDisplayer
    {
        public void Display();
    }

    class ConfigurationDisplayer : IConfigurationDisplayer
    {
        private readonly ILogger<ConfigurationDisplayer> _logger;
        private readonly IConfiguration _configuration;
        private readonly AppConfig _appConfig;

        public ConfigurationDisplayer(ILogger<ConfigurationDisplayer> logger, IConfiguration configuration, AppConfig appConfig)
        {
            _logger = logger;
            _configuration = configuration;
            _appConfig = appConfig;
        }

        public void Display()
        {
            var appConfig = new AppConfig();
            _configuration.GetSection("Appli").Bind(appConfig);
            var comment = _configuration["AppConfig:suite:comment"];
            _logger.LogInformation("AppConfig:suite:comment = " + appConfig.Property_1);
            _logger.LogInformation(" appli.Property_1       = " + appConfig.Property_1);
            _logger.LogInformation("_appli.Property_1       = " + _appConfig.Property_1);
        }
    }
}
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DotNetDependencyInjection.examples._01
{
    public interface ISerializer
    {
        public string Serialize(string toSerialize);
    }

    class Serializer : ISerializer
    {
        private readonly ILogger<Serializer> _logger;
        private readonly IConfiguration _configuration;
        private readonly AppConfig _appConfig;
        private int _counter = 1;

        public Serializer(ILogger<Serializer> logger, IConfiguration configuration, AppConfig appConfig)
        {
            _logger = logger;
            _configuration = configuration;
            _appConfig = appConfig;
        }

        public string Serialize(string toSerialize)
        {
            var appConfig = new AppConfig();
            _configuration.GetSection("Appli").Bind(appConfig);
            var comment = _configuration["AppConfig:suite:comment"];
            _logger.LogInformation("AppConfig:suite:comment = " + appConfig.Property_1);
            _logger.LogInformation(" appli.Property_1       = " + appConfig.Property_1);
            _logger.LogInformation("_appli.Property_1       = " + _appConfig.Property_1);

            _logger.LogInformation("Serialize {} - {}", toSerialize, _counter++);
            return "serialized";
        }
    }
}
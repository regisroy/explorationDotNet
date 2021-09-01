using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DotNetDependencyInjection.examples._01
{
    public class Program
    {
        private static IConfigurationRoot _configurationRoot;

        public static async Task Main(string[] args)
        {
            await CreateHostBuilder1(args).Build().RunAsync();
        }

        private static IHostBuilder CreateHostBuilder1(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, appConfig) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    appConfig
                        // .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables();
                    _configurationRoot = appConfig.Build();
                })
                .ConfigureServices((_, services) =>
                {
                    var appConfig = new AppConfig();
                    _configurationRoot.GetSection(nameof(AppConfig)).Bind(appConfig);
                    services.AddHostedService<Worker>()
                        .AddSingleton<IDatabase, Database>()
                        .AddSingleton<IRepository, Repository>()
                        .AddSingleton<IService, Service>()
                        // .AddScoped<ISerializer, Serializer>()
                        // .AddTransient<ISerializer, Serializer>()
                        .AddSingleton<ISerializer, Serializer>()
                        .AddSingleton<IConfigurationDisplayer, ConfigurationDisplayer>()
                        .AddSingleton(appConfig)
                        ;

                });
    }
}
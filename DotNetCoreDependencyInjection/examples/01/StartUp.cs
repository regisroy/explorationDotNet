using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DotNetDependencyInjection.examples._01
{
    public static class StartUp
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddHostedService<Worker>()
                        .AddSingleton<IMessageWriter, ConsoleMessageWriter>()
                        .AddSingleton<IMessageWriter, LoggingMessageWriter>()
                        .AddSingleton<ExampleService>()
                    )
                // .ConfigureHostConfiguration(configHost => Console.WriteLine("Ici config host"))
                // .ConfigureAppConfiguration((_, appConfig) => Console.WriteLine("Ici config host"))
            ;
    }
}
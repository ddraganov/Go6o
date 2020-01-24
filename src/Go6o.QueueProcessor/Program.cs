using Amazon.SQS;
using Go6o.QueueProcessor.Extensions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;

namespace Go6o.QueueProcessor
{
    public class Program
    {
        private static Func<string, Assembly> AssemblyLoad = (name) => Assembly.Load(name);

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: false, reloadOnChange: true)
                            .Build();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    // AWS Configuration
                    var awsOptions = hostContext.Configuration.GetAWSOptions();
                    services.AddDefaultAWSOptions(awsOptions);
                    services.AddAWSService<IAmazonSQS>();

                    services.AddMediatR(typeof(Program));
                    services.AddMediatorHandlers(AssemblyLoad("Go6o.Core"));

                    services.AddHostedService<Worker>();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                });
    }
}

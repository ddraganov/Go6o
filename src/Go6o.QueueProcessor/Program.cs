using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon.SQS;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Go6o.QueueProcessor
{
    public class Program
    {
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

                    services.AddHostedService<Worker>();
                });
    }
}

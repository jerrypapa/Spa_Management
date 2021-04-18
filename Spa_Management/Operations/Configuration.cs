using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Spa_Management.Operations
{
    public static class Configuration
    {
        private static readonly IConfigurationRoot Configurations = new BootStrap().Setup();

        public static readonly string CRBServiceEndPoint = Configurations["WebService:CRBServiceEndPoint"];
        //public static readonly string Username = Configurations["WebService:Username"];
        //public static readonly string Password = Configurations["WebService:Password"];



        private class BootStrap
        {
            public IConfigurationRoot Setup()
            {
                IHostingEnvironment environment = new HostingEnvironment();

                // Enable to app to read json setting files
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

                if (environment.IsDevelopment())
                {
                    // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                    builder.AddApplicationInsightsSettings(developerMode: true);
                }

                return builder.Build();
            }
        }
    }
}
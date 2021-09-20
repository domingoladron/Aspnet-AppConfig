using System;
using System.IO;

using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using MyApi.Config;

namespace MyApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(
            string[] args)
        {
            var envVarConfig = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            var isFromLocalConfigFile = true;

            if (bool.TryParse(envVarConfig[EnvironmentVariableConstants.UseLocalConfigFile].ToString(), out var useTheLocalConfigFile))
            {
                isFromLocalConfigFile = useTheLocalConfigFile;
            }


            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>()
                            .UseContentRoot(Directory.GetCurrentDirectory())
                            .ConfigureAppConfiguration(
                                (
                                    builder) =>
                                {
                                    if(isFromLocalConfigFile)
                                    {
                                        builder.SetBasePath(Directory.GetCurrentDirectory());
                                        builder.AddJsonFile(
                                            "appsettings.json",
                                            true,
                                            reloadOnChange: true);
                                    }
                                    else 
                                    {

                                        var applicationId = envVarConfig[EnvironmentVariableConstants.AppConfigAppId].ToString();
                                        var environmentId = envVarConfig[EnvironmentVariableConstants.AppConfigEnvironmentId].ToString();
                                        var configProfileId = envVarConfig[EnvironmentVariableConstants.AppConfigProfileId].ToString();
                                        
                                     
                                        builder.AddAppConfig(
                                            applicationId,
                                            environmentId,
                                            configProfileId,
                                            TimeSpan.FromDays(10));
                                    }

                                })
                            .ConfigureLogging(
                                (
                                    hostingContext,
                                    logging) =>
                                {
                                    logging.ClearProviders();
                                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                                    logging.SetMinimumLevel(LogLevel.Information);
                                });
                    });
        }
    }
}

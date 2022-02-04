﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspnetCoreEFCoreExample
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        { 
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    // delete all default configuration providers
                    config.Sources.Clear();
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    config.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json",
                        optional: true);
                })
                .UseStartup<Startup>()
                .Build();
        }
    }
}

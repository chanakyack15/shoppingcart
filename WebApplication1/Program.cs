using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateHostBuilder(args).Build().Run();
            var host = BuildWebHost(args);
            //RunSeeding(host);
            SeedDb(host);
            host.Run();
        }

        private static void SeedDb(IWebHost host)
        {
            // during every req SF creates scope for lifetime
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<WebApplicationSeeder>();
                seeder.seed();
            }
            
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(SetupConfiguration)
            .UseStartup<Startup>()
            .Build();

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();
            builder.AddJsonFile("config.json", false, true)
                .AddEnvironmentVariables();
        }

        /* public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration(SetupConfiguration)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 });

         private static void SetupConfiguration(HostBuilderContext ctx, IConfigurationBuilder builder)
         {
             builder.Sources.Clear();
             builder.AddJsonFile("config.json", false, true)
                 .AddEnvironmentVariables();

         }*/
    }
}

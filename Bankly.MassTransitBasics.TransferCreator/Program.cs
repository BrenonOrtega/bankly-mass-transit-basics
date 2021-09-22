using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bankly.MassTransitBasics.Infra;

namespace Bankly.MassTransitBasics.TransferCreator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(cfgBuilder => cfgBuilder.AddJsonFile("queueSettings.json", optional:false, reloadOnChange: true))
                .ConfigureServices((hostContext, services) =>
                {
                    var config = hostContext.Configuration;
                    services.AddRedisRepository(config);
                    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                    services.Add<Worker>();
                });
    }
}
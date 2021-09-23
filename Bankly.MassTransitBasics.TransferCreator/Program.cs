using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bankly.MassTransitBasics.Infra;
using MassTransit;

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
                .ConfigureHostConfiguration(builder => builder.AddQueueSettings())
                .ConfigureServices((hostContext, services) =>
                {
                    var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                    var config = hostContext.Configuration;
                    services.AddRedisRepository(config);
                    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                    services.AddMassTransitWithRabbitMq(config, assemblies, useHostedServices: true);
                });
    }
}

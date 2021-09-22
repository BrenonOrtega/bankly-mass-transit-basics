using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bankly.MassTransitBasics.Infra;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bankly.MassTransitBasics.TaxApplier
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
                    var config = hostContext.Configuration;
                    services.AddRedisRepository(config);
                    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                    services.AddMassTransitWithRabbitMq(config, useHostedServices: true);
                });
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bankly.MassTransitBasics.Infra;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;

namespace Bankly.MassTransitBasics.OperationalTransfer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(x => x.AddQueueSettings())
                .ConfigureServices((hostContext, services) =>
                {
                    var config = hostContext.Configuration;
                    var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                    services.AddRedisRepository(config);
                    services.AddAutoMapper(assemblies);
                    services.AddMassTransitWithRabbitMq(config, assemblies, useHostedServices: true);
                });
    }
}

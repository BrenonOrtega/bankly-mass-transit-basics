using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;

namespace Bankly.MassTransitBasics.Infra
{
    public static class ConfigurationExtensions
    {
        public static IConfigurationBuilder AddQueueSettings(this IConfigurationBuilder builder) => 
            builder.AddJsonFile("queueSettings.json", optional: false, reloadOnChange:true);
        
        public static IServiceCollection AddRedisRepository(this IServiceCollection services, IConfiguration config)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                var defaultDb = config["Redis:Database"] ?? throw new ArgumentException("database not defined", nameof(ConfigurationOptions.DefaultDatabase));

                options.Configuration = config.GetConnectionString("redis");
                options.ConfigurationOptions = new ConfigurationOptions()
                {
                    DefaultDatabase = Int32.Parse(defaultDb)
                };
            });

            services.AddScoped(typeof(IRepository<>), typeof(RedisRepository<>));
            return services;
        }

        public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services, IConfiguration config, bool useHostedServices)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(config["RabbitMq:Hostname"], host =>
                    {
                        host.Password(config["RabbitMq:Password"]);
                        host.Username(config["RabbitMq:Username"]);
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });

            if (useHostedServices)
                services.AddMassTransitHostedService();

            return services;
        }
    }
}
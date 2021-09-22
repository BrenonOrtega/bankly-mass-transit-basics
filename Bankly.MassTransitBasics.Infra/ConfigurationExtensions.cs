using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;

namespace Bankly.MassTransitBasics.Infra
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddRedisRepository(this IServiceCollection services, IConfiguration config)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                var defaultDb = config["redis:database"] ?? throw new ArgumentException("database not defined", nameof(ConfigurationOptions.DefaultDatabase));
                
                options.Configuration = config.GetConnectionString("redis");
                options.ConfigurationOptions = new ConfigurationOptions()
                {
                    DefaultDatabase = Int32.Parse(defaultDb)
                };
            });

            services.AddScoped(typeof(IRepository<>), typeof(RedisRepository<>));
            return services;
        }
    }
}
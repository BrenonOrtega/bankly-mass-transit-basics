using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Bankly.MassTransitBasics.Infra
{
    public class RedisRepository<T> : IRepository<T>
    {
        private readonly IDatabase _database;
        public RedisRepository(IConfiguration config)
        {
            var database = config["Redis:Database"] ?? throw new ArgumentException("Config[\"Redis:Database\"]");
            _database = ConnectionMultiplexer.Connect(config.GetConnectionString("Redis")).GetDatabase(int.Parse(database));
        }

        public Task AddAsync<V>(V storeKey, T entity)
        {
            var serializedData = JsonSerializer.SerializeToUtf8Bytes(entity, new JsonSerializerOptions { WriteIndented = true });
            return _database.SetAddAsync(storeKey.ToString(), serializedData);
        }

        public async Task<T> GetOneAsync<V>(V storeKey)
        {
            var data = await _database.StringGetAsync(storeKey.ToString());
            var deserializedEntity = JsonSerializer.Deserialize<T>(data);
            return deserializedEntity;
        }
    }
}

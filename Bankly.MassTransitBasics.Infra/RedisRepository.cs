using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Bankly.MassTransitBasics.Infra
{
    public class RedisRepository<T> : IRepository<T>
    {
        private readonly IDatabase _database;
        public RedisRepository(IDatabase database)
        {
            _database = database ?? throw new ArgumentException(nameof(database));
        }

        public Task AddAsync<V>(V storeKey, T entity)
        {
            var serializedData = JsonSerializer.Serialize(entity, new JsonSerializerOptions { WriteIndented = true });
            return _database.StringAppendAsync(new RedisKey(storeKey.ToString()), serializedData);
        }

        public async Task<T> GetOneAsync<V>(V storeKey)
        {
            var data = await _database.StringGetAsync(new RedisKey(storeKey.ToString()));
            var deserializedEntity = JsonSerializer.Deserialize<T>(data);
            return deserializedEntity;
        }
    }
}

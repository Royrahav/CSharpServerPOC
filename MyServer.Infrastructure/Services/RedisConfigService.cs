using MyServer.Application.Entities;
using MyServer.Application.Interfaces;
using StackExchange.Redis;

namespace MyServer.Infrastructure.Services
{
    public class RedisConfigService : IRedisConfigService
    {
        private readonly StackExchange.Redis.IDatabase _db;

        public RedisConfigService(IConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase();
        }

        public async Task<List<RedisConfigEntry>> LoadConfigsAsync(string[] keys)
        {
            var result = new List<RedisConfigEntry>();
            foreach (var key in keys)
            {
                var value = await _db.StringGetAsync(key);
                result.Add(new RedisConfigEntry
                {
                    Key = key,
                    Value = value.HasValue ? value.ToString() : string.Empty,
                    Exists = value.HasValue
                });
            }
            return result;
        }
    }
}

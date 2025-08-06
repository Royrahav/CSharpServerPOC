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
            var redisKeys = keys.Select(k => (RedisKey)k).ToArray();
            var values = await _db.StringGetAsync(redisKeys);
            
            var result = new List<RedisConfigEntry>(keys.Length);
            for (int i = 0; i < keys.Length; i++)
            {
                result.Add(new RedisConfigEntry
                {
                    Key = keys[i],
                    Value = values[i].HasValue ? values[i].ToString() : string.Empty,
                    Exists = values[i].HasValue
                });
            }
            return result;

            // Option 2: Parallel execution (if MGET isn't suitable)
            /*
            var tasks = keys.Select(async key =>
            {
                var value = await _db.StringGetAsync(key);
                return new RedisConfigEntry
                {
                    Key = key,
                    Value = value.HasValue ? value.ToString() : string.Empty,
                    Exists = value.HasValue
                };
            });

            return (await Task.WhenAll(tasks)).ToList();
            */
        }
    }
}

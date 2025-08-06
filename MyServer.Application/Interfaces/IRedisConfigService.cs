using MyServer.Application.Entities;

namespace MyServer.Application.Interfaces
{
    public interface IRedisConfigService
    {
        Task<List<RedisConfigEntry>> LoadConfigsAsync(string[] keys);
        List<RedisConfigEntry> LoadConfigs(string[] keys);
    }
}

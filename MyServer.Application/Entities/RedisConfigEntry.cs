namespace MyServer.Application.Entities
{
    public class RedisConfigEntry
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public bool Exists { get; set; }
    }
}

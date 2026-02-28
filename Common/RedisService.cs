using StackExchange.Redis;

public class RedisService(IConnectionMultiplexer redis)
{
    public async Task PushToListAsync(string key, string value) => await redis.GetDatabase().ListLeftPushAsync(key, value);
    public async Task<object> PopFromListAsync(string key) => (await redis.GetDatabase().ListRightPopAsync(key)).ToString();
}
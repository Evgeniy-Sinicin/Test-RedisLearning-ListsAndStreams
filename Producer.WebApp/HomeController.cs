
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

public class HomeController(IOptions<AppOptions> appOptions, RedisService redisService) : ControllerBase
{
    public IActionResult Index() => Ok("Producer");

    public async Task<IActionResult> Enqueue(int id, string payload)
    {
        var record = new { Id = id, Payload = payload };
        var json = JsonSerializer.Serialize(record);
        await redisService.PushToListAsync(appOptions.Value.Redis.ListKey, json);
        return Ok(record);
    }
}
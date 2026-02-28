
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

public class HomeController(IOptions<AppOptions> appOptions, RedisService redisService) : ControllerBase
{
    public IActionResult Index() => Ok("Consumer");

    public async Task<IActionResult> Dequeue() => Ok(await redisService.PopFromListAsync(appOptions.Value.Redis.ListKey));
}

using Microsoft.AspNetCore.Mvc;

public class HomeController : ControllerBase
{
    public IActionResult Index() => Ok("Producer");

    public IActionResult Enqueue(int id, string payload)
    {
        return Ok(new { Id = id, Payload = payload });
    }
}
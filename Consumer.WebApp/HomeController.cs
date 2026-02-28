
using Microsoft.AspNetCore.Mvc;

public class HomeController : ControllerBase
{
    public IActionResult Index() => Ok("Consumer");

    public IActionResult Dequeue()
    {
        return Ok(nameof(Dequeue));
    }
}
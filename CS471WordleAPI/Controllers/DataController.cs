using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

[ApiController]
[Route("api/[controller]")]
public class DataController : ControllerBase
{
    private readonly IWebHostEnvironment _env;

    public DataController(IWebHostEnvironment env)
    {
        _env = env;
    }

    [HttpGet]
    public IActionResult Read()
    {
        var path = Path.Combine(_env.ContentRootPath, "Data", "Data.json");
        var json = System.IO.File.ReadAllText(path);
        return Content(json, "application/json");
    }

    [HttpPost]
    public IActionResult Write([FromBody] object data)
    {
        var path = Path.Combine(_env.ContentRootPath, "Data", "Data.json");
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        System.IO.File.WriteAllText(path, json);
        return Ok();
    }
}

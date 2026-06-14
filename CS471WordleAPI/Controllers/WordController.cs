using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

[ApiController]
[Route("api/[controller]")]
public class WordController : ControllerBase
{
    private readonly IWebHostEnvironment _env;

    /*
        Function Name: WordController
        Input: Hosting env info
        Output: new WordController object
        Brief description:
            Initializes conrtoller and provides acess to app's root directory
    */

    public WordController(IWebHostEnvironment env)
    {
        _env = env;
    }

    /*
        Function Name: Read
        Input: N/A
        Output: data stores in Data.json
        Brief description:
            Reads app data from database file and returns to client
    */

    [HttpGet]
    public IActionResult Read()
    {
        var path = Path.Combine(_env.ContentRootPath, "Data", "ValidWords.json");
        var json = System.IO.File.ReadAllText(path);
        return Content(json, "application/json");
    }

    /*
        Function Name: Write
        Input: app data from client
        Output: Ok() response that file was updated
        Brief description:
            Serializes new data and stores in Data.json
    */

    [HttpPost]
    public IActionResult Write([FromBody] object data)
    {
        var path = Path.Combine(_env.ContentRootPath, "Data", "ValidWords.json");
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        System.IO.File.WriteAllText(path, json);
        return Ok();
    }
}
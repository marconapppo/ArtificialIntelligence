using Microsoft.AspNetCore.Mvc;

namespace ArtificialIntelligence.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtificialIntelligenceController : ControllerBase
{

    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult Get()
    {
        return Ok();
    }
}
using ArtificialIntelligence.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArtificialIntelligence.Controllers;

[ApiController]
[Route("[controller]")]
public class OpenAiController : ControllerBase
{
    private readonly IOpenAiService _openAiService;

    public OpenAiController(IOpenAiService openAiService)
    {
        _openAiService = openAiService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<ActionResult> Get(string prompt, string apiKey)
    {
        var result = await _openAiService.GetImage(prompt, apiKey);

        return Ok();
    }
}
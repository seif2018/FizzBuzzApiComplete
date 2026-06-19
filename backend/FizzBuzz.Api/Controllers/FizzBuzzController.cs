using FizzBuzz.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzz.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class FizzBuzzController : ControllerBase
{
    private readonly IFizzBuzzService _service;
    private readonly ILogger<FizzBuzzController> _logger;

    public FizzBuzzController(IFizzBuzzService service, ILogger<FizzBuzzController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IReadOnlyList<string>> Get([FromQuery] int int1, [FromQuery] int int2, [FromQuery] int limit, [FromQuery] string str1, [FromQuery] string str2)
    {
        _logger.LogInformation("Generating FizzBuzz with int1={Int1}, int2={Int2}, limit={Limit}", int1, int2, limit);
        return Ok(_service.Generate(new FizzBuzzRequest(int1, int2, limit, str1, str2)));
    }
}

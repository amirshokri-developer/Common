using Microsoft.AspNetCore.Mvc;

namespace Common.Meetings.API.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]

[ApiController]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;
    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }
    
    
    [HttpGet]
    public ActionResult Hi(CancellationToken cancellationToken)
    {
        _logger.LogInformation("hello world");
        
        return Ok();
    }

}
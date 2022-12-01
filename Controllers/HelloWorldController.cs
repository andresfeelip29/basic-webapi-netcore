using Microsoft.AspNetCore.Mvc;
using webapi.Services;


[ApiController]
[Route("api/v1/[controller]")]
public class HelloWorldController : ControllerBase
{

    IHelloWorldService helloWorldService;
    private readonly ILogger<HelloWorldController> _logger;


    public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger)
    {
        this._logger = logger;
        this.helloWorldService = helloWorld;
    }

   [HttpGet]
    public IActionResult Get(){

        _logger.LogInformation("Se retrana mensaje en clase HelloWorldController");
        return Ok(helloWorldService.GetHelloWorld());
    }

}

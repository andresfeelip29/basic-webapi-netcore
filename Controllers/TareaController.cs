using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;


namespace webapi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TareaController : ControllerBase
{

    ITareaService tareaService;

    private readonly ILogger<TareaController> _logger;
    public TareaController(ITareaService service, ILogger<TareaController> logger)
    {

        this._logger = logger;
        this.tareaService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Se obtiene la lista de Categorias");
        return Ok(tareaService.get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
    
        return Ok(this.tareaService.Save(tarea));
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea)
    {

        this.tareaService.Update(id, tarea);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {

        this.tareaService.Delete(id);
        return Ok();
    }


}

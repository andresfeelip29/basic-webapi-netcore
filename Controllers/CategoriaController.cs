using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;


namespace webapi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CategoriaController : ControllerBase
{


    ICategoriaService cantegoriaService;
    private readonly ILogger<CategoriaController> _logger;

    public CategoriaController(ICategoriaService categoriaService, ILogger<CategoriaController> logger)
    {
        this.cantegoriaService = categoriaService;
        this._logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Se obtiene la lista de Categorias");
        return Ok(cantegoriaService.get());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Categoria categoria)
    {

        return Ok(this.cantegoriaService.Save(categoria));
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Categoria categoria)
    {

        this.cantegoriaService.Update(id, categoria);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {

        this.cantegoriaService.Delete(id);
        return Ok();
    }
}
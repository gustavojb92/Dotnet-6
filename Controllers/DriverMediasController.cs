using Microsoft.AspNetCore.Mvc;
using Dotnet_6.Data;
using Dotnet_6.Models;
using Dotnet_6.Domain;
using Dotnet_6.Models.Dto.DriverMedia;
using Dotnet_6.Interfaces;

[Route("/api/[controller]")]
[ApiController]
public class DriverMediasController : ControllerBase
{
    private static IDriverMedia _iDriverMedia;
    public DriverMediasController(IDriverMedia iDriverMedia)
    {
        _iDriverMedia = iDriverMedia;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var driverMedias = _iDriverMedia.GetAll();

        return driverMedias == null ? NotFound("Não há medias cadastradas") : Ok(driverMedias);
    }

    [HttpGet("{ID}")]
    public IActionResult Get(int ID)
    {
        var selectedDriverMedia = _iDriverMedia.GetById(ID);

        return selectedDriverMedia == null ? BadRequest(error: "Não encontrado") : Ok(selectedDriverMedia);
    }

    [HttpPost]
    public IActionResult Post(AddDriverMediaDTO driverMediaDTO)
    {
        var newDriverMedia = _iDriverMedia.Post(driverMediaDTO);
        return newDriverMedia == null ? BadRequest("Não foi possivel salvar") : CreatedAtAction("Get", routeValues: newDriverMedia.Id, value: newDriverMedia);

    }

    [HttpDelete("{ID}")]
    public IActionResult Delete(int ID)
    {
        var deleteDriverMedia = _iDriverMedia.Delete(ID);
        return deleteDriverMedia ? NoContent() : BadRequest(error: "Não encontrado");
    }
}

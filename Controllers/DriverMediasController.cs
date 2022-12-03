using Microsoft.AspNetCore.Mvc;
using Dotnet_6.Data;
using Dotnet_6.Models;


[Route("/api/[controller]")]
[ApiController]
public class DriverMediasController : ControllerBase
{
    private static ApiDbContext _context;
    public DriverMediasController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var driverMedias = _context.DriverMedias.ToList();

        return Ok(driverMedias);
    }

    [HttpGet("{ID}")]
    public IActionResult Get(int ID)
    {
        var selectedDriverMedia = _context.DriverMedias.FirstOrDefault(x => x.Id == ID);

        return selectedDriverMedia == null ? BadRequest(error: "Não encontrado") : Ok(selectedDriverMedia);
    }

    [HttpPost]
    public IActionResult Post(DriverMedia newDriverMedia)
    {
        _context.DriverMedias.Add(newDriverMedia);
        _context.SaveChanges();
        return CreatedAtAction("Get", routeValues: newDriverMedia.Id, value: newDriverMedia);

    }

    [HttpPatch("{ID}")]
    public IActionResult Patch(int ID, string media)
    {
        var editDriverMedias = _context.DriverMedias.FirstOrDefault(x => x.Id == ID);

        if (editDriverMedias == null) return BadRequest(error: "Não Encontrado");

        editDriverMedias.Media = media;
        _context.SaveChanges();
        return NoContent();

    }

    [HttpDelete("{ID}")]
    public IActionResult Delete(int ID)
    {
        var deleteDriverMedia = _context.DriverMedias.FirstOrDefault(x => x.Id == ID);

        if (deleteDriverMedia == null) return BadRequest(error: "Não encontrado");

        _context.DriverMedias.Remove(deleteDriverMedia);
        _context.SaveChanges();
        return NoContent();
    }
}

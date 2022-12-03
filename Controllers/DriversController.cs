using Microsoft.AspNetCore.Mvc;
using Dotnet_6.Models;
using Dotnet_6.Data;

[Route("/api/[controller]")]
[ApiController]
public class DriversController : ControllerBase
{
    private static ApiDbContext _context;

    public DriversController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var drivers = _context.Drivers.ToList();
        return Ok(drivers);
    }

    [HttpGet("{ID}")]
    public IActionResult Get(int ID)
    {
        var selectedDriver = _context.Drivers.FirstOrDefault(x => x.Id == ID);

        return selectedDriver == null ? BadRequest("Não encontrado") : Ok(selectedDriver);
    }

    [HttpPost]
    public IActionResult Post(Driver newDriver)
    {
        _context.Drivers.Add(newDriver);
        _context.SaveChanges();
        return CreatedAtAction("Get", routeValues: newDriver.Id, value: newDriver);
    }

    [HttpPatch("{ID}")]
    public IActionResult Patch(int ID, string NewFavoriteColor)
    {
        var editDriver = _context.Drivers.FirstOrDefault(x => x.Id == ID);

        if (editDriver == null) return BadRequest(error: "Não encontrado");

        editDriver.FavoriteColor = NewFavoriteColor;
        _context.SaveChanges();
        return NoContent();

    }

    [HttpDelete("{ID}")]
    public IActionResult Delete(int ID)
    {
        var deleteDriver = _context.Drivers.FirstOrDefault(x => x.Id == ID);

        if (deleteDriver == null) return BadRequest(error: "Não encontrado");

        _context.Drivers.Remove(deleteDriver);
        _context.SaveChanges();
        return NoContent();
    }
}

using Microsoft.AspNetCore.Mvc;
using Dotnet_6.Models;
using Dotnet_6.Data;

[Route("/api/[controller]")]
[ApiController]
public class TeamsController : ControllerBase
{

    private static ApiDbContext _context;
    public TeamsController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var teams = _context.Teams.ToList();
        return Ok(teams);
    }

    [HttpGet("{ID}")]
    public IActionResult Get(int ID)
    {
        var selectedTeam = _context.Teams.FirstOrDefault(x => x.Id == ID);

        return selectedTeam == null ? BadRequest(error: "Não encontrado") : Ok(selectedTeam);
    }

    [HttpPost]
    public IActionResult Post(Team newTeam)
    {
        _context.Teams.Add(newTeam);
        _context.SaveChanges();
        return CreatedAtAction("Get", routeValues: newTeam.Id, value: newTeam);
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, string name)
    {
        var editTeam = _context.Teams.FirstOrDefault(x => x.Id == id);

        if (editTeam == null) return BadRequest(error: "Não encontrado");

        editTeam.Name = name;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleteTeam = _context.Teams.FirstOrDefault(x => x.Id == id);

        if (deleteTeam == null) return BadRequest(error: "Não encontrado");

        _context.Teams.Remove(deleteTeam);
        _context.SaveChanges();
        return NoContent();
    }
}

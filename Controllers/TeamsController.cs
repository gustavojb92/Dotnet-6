using Microsoft.AspNetCore.Mvc;
using Dotnet_6.Models;
using Dotnet_6.Data;
using Dotnet_6.Domain;
using Dotnet_6.Models.Dto.Team;
using Dotnet_6.Interfaces;

[Route("/api/[controller]")]
[ApiController]
public class TeamsController : ControllerBase
{

    private static ITeam _iTeam;
    public TeamsController(ITeam iteam)
    {
        _iTeam = iteam;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var teams = _iTeam.GetAll();
        return teams == null ? NotFound("Não há Times cadastrados") : Ok(teams);
    }

    [HttpGet("{ID}")]
    public IActionResult Get(int ID)
    {
        var selectedTeam = _iTeam.GetById(ID);

        return selectedTeam == null ? BadRequest(error: "Não encontrado") : Ok(selectedTeam);
    }

    [HttpPost]
    public IActionResult Post(AddTeamDTO newTeam)
    {
        var team = _iTeam.Post(newTeam);
        return  team == null ? BadRequest("Não foi possivel salvar") : CreatedAtAction("Get", routeValues: team.Id , value: team);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleteTeam = _iTeam.Delete(id);

        return deleteTeam ? NoContent() : BadRequest(error: "Não encontrado");
    }
}

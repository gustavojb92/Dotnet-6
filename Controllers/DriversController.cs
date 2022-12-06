using Microsoft.AspNetCore.Mvc;
using Dotnet_6.Models;
using Dotnet_6.Domain;
using Dotnet_6.Models.Dto.Driver;
using Dotnet_6.Interfaces;
using Dotnet_6.Exceptions.Interface;
using FluentResults;

[Route("/api/[controller]")]
[ApiController]
public class DriversController : ControllerBase
{
    private static IDriver _iDriver;

    public readonly IDriverException _iDriverException;

    public DriversController(DriverDomain iDriver, IDriverException iDriverException)
    {
        _iDriver = iDriver;
        _iDriverException = iDriverException;
    }

    public static IEnumerable<String> messageException(Result resultado)
    {
        return resultado.Reasons.Select(reason => reason.Message);
    }

    [HttpGet]
    public IActionResult Get()
    {
        var drivers = _iDriver.GetAll();
        return drivers == null ? NotFound("Nenhum piloto encontrado") : Ok(drivers);
    }

    [HttpGet("{ID}")]
    public IActionResult Get(int ID)
    {
        var selectedDriver = _iDriver.GetById(ID);

        return selectedDriver == null ? NotFound("Não encontrado") : Ok(selectedDriver);
    }

    [HttpPost]
    public IActionResult Post(AddDriverDTO driverDTO)
    {
        Result driverException = _iDriverException.NoRepeatDriverException(driverDTO.Name);

        if (driverException.IsFailed) return BadRequest(messageException(driverException));

        var newDriver = _iDriver.Post(driverDTO);

        return newDriver == null ? BadRequest("Não foi possivel salvar") : CreatedAtAction("Get", routeValues: newDriver.Id, value: newDriver);
    }

    [HttpDelete("{ID}")]
    public IActionResult Delete(int ID)
    {
        var deleteDriver = _iDriver.Delete(ID);
        return deleteDriver ? Ok() : BadRequest(error: "Não encontrado");
    }
}

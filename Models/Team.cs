
namespace Dotnet_6.Models;

public class Team : BaseEntity
{

    public string Name { get; set; } = "";

    public Int16 Year { get; set; } = 2022;

    public virtual List<Driver> Drivers { get; set; }
}


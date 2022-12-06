
namespace Dotnet_6.Models.Dto.Team
{
    public class ReadTeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Int16 Year { get; set; }

        public virtual List<Models.Driver> Drivers { get; set; }
    }
}
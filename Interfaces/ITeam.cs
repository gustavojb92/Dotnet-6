using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_6.Models.Dto.Team;

namespace Dotnet_6.Interfaces
{
    public interface ITeam : IBase<AddTeamDTO, ReadTeamDTO>
    {
        
    }
}
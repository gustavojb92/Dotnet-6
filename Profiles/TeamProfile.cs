
using AutoMapper;
using Dotnet_6.Models.Dto.Team;
using Dotnet_6.Models;

namespace Dotnet_6.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<AddTeamDTO, Team>();
            CreateMap<Team, ReadTeamDTO>();
        }
    }
}
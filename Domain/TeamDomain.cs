
using AutoMapper;
using Dotnet_6.Data;
using Dotnet_6.Interfaces;
using Dotnet_6.Models;
using Dotnet_6.Models.Dto.Team;

namespace Dotnet_6.Domain
{
    public class TeamDomain : ITeam
    {
        public readonly ApiDbContext _context;
        public readonly IMapper _mapper;

        public TeamDomain(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ReadTeamDTO> GetAll()
        {
            var teams = _context.Teams.ToList();
            IEnumerable<ReadTeamDTO> teamsDTO = _mapper.Map<List<ReadTeamDTO>>(teams);
            return teamsDTO;
        }

        public ReadTeamDTO GetById(int id)
        {
            var selectedTeam = _context.Teams.FirstOrDefault(x => x.Id == id);
            ReadTeamDTO teamDTO = _mapper.Map<ReadTeamDTO>(selectedTeam);
            return teamDTO;
        }

        public ReadTeamDTO Post(AddTeamDTO teamDTO)
        {
            Team team = _mapper.Map<Team>(teamDTO);
            _context.Teams.Add(team);
            _context.SaveChanges();
            ReadTeamDTO newTeam = _mapper.Map<ReadTeamDTO>(team);
            return newTeam;
        }

        public Boolean Delete(int id)
        {
            var deleteTeam = _context.Teams.FirstOrDefault(x => x.Id == id);
            if (deleteTeam == null) return false;

        _context.Teams.Remove(deleteTeam);
        _context.SaveChanges();
        return true;
        }
    }
}

using AutoMapper;
using Dotnet_6.Data;
using Dotnet_6.Interfaces;
using Dotnet_6.Models;
using Dotnet_6.Models.Dto.DriverMedia;

namespace Dotnet_6.Domain
{
    public class DriverMediaDomain : IDriverMedia
    {

        public readonly ApiDbContext _context;

        public readonly IMapper _mapper;

        public DriverMediaDomain(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ReadDriverMediaDTO> GetAll()
        {
            var driverMedias = _context.DriverMedias.ToList();
            IEnumerable<ReadDriverMediaDTO> driverMediasDTO = _mapper.Map<List<ReadDriverMediaDTO>>(driverMedias);
            return driverMediasDTO;
        }

        public ReadDriverMediaDTO GetById(int id)
        {
            var selectedDriverMedia = _context.DriverMedias.FirstOrDefault(x => x.Id == id);
            ReadDriverMediaDTO driverMediaDTO = _mapper.Map<ReadDriverMediaDTO>(selectedDriverMedia);
            return driverMediaDTO;
        }

        public ReadDriverMediaDTO Post(AddDriverMediaDTO driverMediaDTO)
        {
            DriverMedia driverMedia = _mapper.Map<DriverMedia>(driverMediaDTO);
            _context.DriverMedias.Add(driverMedia);
            _context.SaveChanges();
            ReadDriverMediaDTO newDriverMedia = _mapper.Map<ReadDriverMediaDTO>(driverMedia);
            return newDriverMedia;
        }

        public Boolean Delete(int id)
        {
            var deleteDriverMedia = _context.DriverMedias.FirstOrDefault(x => x.Id == id);
            if (deleteDriverMedia == null) return false;
            _context.DriverMedias.Remove(deleteDriverMedia);
            _context.SaveChanges();
            return true;
        }
    }
}
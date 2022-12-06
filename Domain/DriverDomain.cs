

using AutoMapper;
using Dotnet_6.Data;
using Dotnet_6.Models.Dto.Driver;
using Dotnet_6.Models;
using Dotnet_6.Interfaces;

namespace Dotnet_6.Domain
{
    public class DriverDomain : IDriver
    {
        public readonly ApiDbContext _context;
        public readonly IMapper _mapper;
        public DriverDomain(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ReadDriverDTO> GetAll()
        {
            var drivers = _context.Drivers.ToList();
            IEnumerable<ReadDriverDTO> driverDTOs = _mapper.Map<List<ReadDriverDTO>>(drivers);
            return driverDTOs;
        }

        public ReadDriverDTO GetById(int id)
        {
            var selectedDriver = _context.Drivers.FirstOrDefault(x => x.Id == id);
            ReadDriverDTO driverDTO = _mapper.Map<ReadDriverDTO>(selectedDriver);
            return driverDTO;
        }

        public ReadDriverDTO Post(AddDriverDTO driverDTO)
        {
            Driver driver = _mapper.Map<Driver>(driverDTO);
            _context.Drivers.Add(driver);
            _context.SaveChanges();
            ReadDriverDTO newDriver = _mapper.Map<ReadDriverDTO>(driver);
            return newDriver;
        }

        public Boolean Delete(int id)
        {
            var deleteDriver = _context.Drivers.FirstOrDefault(x => x.Id == id);

            if (deleteDriver == null) return false;

            _context.Drivers.Remove(deleteDriver);
            _context.SaveChanges();
            return true;
        }
    }
}
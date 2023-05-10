using AutoMapper;
using Dotnet_6.Data;
using Dotnet_6.Exceptions.Interface;
using FluentResults;

namespace Dotnet_6.Exceptions
{
    public class DriverException : IDriverException
    {
        public readonly ApiDbContext _context;

        public readonly IMapper _mapper;

        public DriverException(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Result NoRepeatDriverException(string driverName)
        {
            var findDriver = _context.Drivers.FirstOrDefault(x => x.Name == driverName);
            return findDriver != null ? Result.Fail("Piloto já cadastrado") : Result.Ok();
        }
    }
}
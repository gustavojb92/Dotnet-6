
using AutoMapper;
using Dotnet_6.Models;
using Dotnet_6.Models.Dto.Driver;

namespace Dotnet_6.Profiles
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<AddDriverDTO, Driver>();
            CreateMap<Driver, ReadDriverDTO>();
        }
    }
}
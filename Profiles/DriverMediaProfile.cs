using Dotnet_6.Models;
using Dotnet_6.Models.Dto.DriverMedia;
using AutoMapper;

namespace Dotnet_6.Profiles
{
    public class DriverMediaProfile : Profile
    {
        public DriverMediaProfile()
        {
            CreateMap<AddDriverMediaDTO, DriverMedia>();
            CreateMap<DriverMedia, ReadDriverMediaDTO>();

        }
    }
}
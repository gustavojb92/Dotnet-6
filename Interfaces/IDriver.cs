using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_6.Models.Dto.Driver;

namespace Dotnet_6.Interfaces
{
    public interface IDriver : IBase<AddDriverDTO, ReadDriverDTO>
    {
        
    }
}
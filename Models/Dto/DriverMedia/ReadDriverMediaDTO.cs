using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_6.Models.Dto.DriverMedia
{
    public class ReadDriverMediaDTO
    {
        public int Id { get; set; }
        public string Media { get; set; }

        public virtual Models.Driver Driver { get; set; }
    }
}
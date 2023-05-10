using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dotnet_6.Models.Dto.Driver
{
    public class ReadDriverDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int RaceingNumber { get; set; }

        public string FavoriteColor { get; set; }

        public virtual Models.Team Team { get; set; }

    }
}
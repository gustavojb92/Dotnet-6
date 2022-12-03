using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_6.Models;

public class Driver : BaseEntity
{
    public int TeamId { get; set; }

    public string Name { get; set; } = "";

    public int RaceingNumber { get; set; }

    public string FavoriteColor { get; set; } = "";

    public virtual Team Team { get; set; }
    public virtual DriverMedia DriverMedia { get; set; }
}

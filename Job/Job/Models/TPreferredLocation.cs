using System;
using System.Collections.Generic;

namespace Job.Models;

public partial class TPreferredLocation
{
    public int LocationId { get; set; }

    public int ProfileId { get; set; }

    public bool NorthRegion { get; set; }

    public bool CentralRegion { get; set; }

    public bool SouthRegion { get; set; }

    public bool EastRegion { get; set; }

    public bool IslandsRegion { get; set; }
}

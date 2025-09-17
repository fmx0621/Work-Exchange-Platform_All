using System;
using System.Collections.Generic;

namespace Job.Models;

public partial class TManager
{
    public int ManagerId { get; set; }

    public string? ManagerName { get; set; }

    public string? Account { get; set; }

    public string? Password { get; set; }

    public int? PermissionId { get; set; }

    public string? PermissionName { get; set; }

    public string? Email { get; set; }

    public bool? EmailConfirmed { get; set; }
}

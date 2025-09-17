using System;
using System.Collections.Generic;

namespace Job.Models;

public partial class TPermission
{
    public int? PermissionId { get; set; }

    public int? MemberId { get; set; }

    public string? PermissionName { get; set; }
}

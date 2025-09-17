using System;
using System.Collections.Generic;

namespace Job.Models;

public partial class TMember
{
    public int MemberId { get; set; }

    public string? Account { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? PermissionId { get; set; }

    public string? PermissionName { get; set; }
}

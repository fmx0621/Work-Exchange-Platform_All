using System;
using System.Collections.Generic;

namespace Job.Models;

public partial class TUserManagerMent
{
    public int ManagerMentId { get; set; }

    public int? Points { get; set; }

    public int? PermissionId { get; set; }

    public int? UserRecordId { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public string? HonorTitle { get; set; }

    public int? MemberId { get; set; }
}

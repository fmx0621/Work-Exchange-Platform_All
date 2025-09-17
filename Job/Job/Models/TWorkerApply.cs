using System;
using System.Collections.Generic;

namespace Job.Models;

public partial class TWorkerApply
{
    public int WorkerApplyId { get; set; }

    public int MemberId { get; set; }

    public string? WorkerName { get; set; }

    public string ApplyOwner { get; set; } = null!;

    public string ApplyPosition { get; set; } = null!;

    public DateTime ApplyDate { get; set; }

    public string ApplySituation { get; set; } = null!;

    public string Introduction { get; set; } = null!;

    public int SnapShotId { get; set; }
}

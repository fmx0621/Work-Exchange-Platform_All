using System;
using System.Collections.Generic;

namespace Job.Models;

public partial class TOwnerAdmission
{
    public int OwnerAdmissionId { get; set; }

    public string? ApplyOwner { get; set; }

    public int MemberId { get; set; }

    public string WorkerName { get; set; } = null!;

    public string AdmissionPosition { get; set; } = null!;

    public DateTime AdmissionDate { get; set; }

    public string ReplySituation { get; set; } = null!;

    public DateTime WorkStartDate { get; set; }

    public DateTime WorkEndDate { get; set; }
}

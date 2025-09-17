using System;
using System.Collections.Generic;

namespace Job.Models;

public partial class TCompanyVerification
{
    public int VerificationId { get; set; }

    public int MemberId { get; set; }

    public string RegisteredName { get; set; } = null!;

    public string OwnerName { get; set; } = null!;

    public string RegisteredAddress { get; set; } = null!;

    public string? BusinessRegNo { get; set; }

    public DateOnly EstablishedDate { get; set; }

    public string CompanyLicenseImage { get; set; } = null!;

    public DateTime SubmittedAt { get; set; }

    public DateTime? ApprovedAt { get; set; }
}

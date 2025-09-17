using System;
using System.Collections.Generic;

namespace Job.Models;

public partial class TApplication
{
    public int ApplicationId { get; set; }

    public int ListingId { get; set; }

    public int ResumeId { get; set; }

    public string? CoverLetter { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly? WorkStartDate { get; set; }

    public DateOnly? WorkEndDate { get; set; }

    public string? SpecialRequirements { get; set; }

    public DateTime AppliedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

using System;
using System.Collections.Generic;

namespace Job.Models;

public partial class TJobPostingDetail
{
    public int DetailId { get; set; }

    public int? PostingId { get; set; }

    public string? Description { get; set; }

    public int? PeopleRequired { get; set; }

    public string? WorkingHours { get; set; }

    public string? DayOff { get; set; }

    public bool? RequiredExperience { get; set; }

    public string? RequiredSkills { get; set; }

    public string? RequiredLincenses { get; set; }

    public string? BenefitsTags { get; set; }

    public string? BenefitsText { get; set; }

    public string? Notice { get; set; }

    public string? CoverImage { get; set; }

    public string? EnvironmentImage { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}

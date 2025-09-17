using System;
using System.Collections.Generic;

namespace Job.Models;

public partial class TMemberProfile
{
    public int ProfileId { get; set; }

    public int MemberId { get; set; }

    public string Name { get; set; } = null!;

    public string? Sex { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? ProfilePicture { get; set; }

    public string? Education { get; set; }

    public string? Languages { get; set; }

    public string? WorkExperience { get; set; }

    public string? Licenses { get; set; }

    public DateOnly? AvailableFrom { get; set; }

    public DateOnly? AvailableTo { get; set; }

    public string? PreferredCategories { get; set; }

    public string? ExpectedBenefits { get; set; }

    public string? Motivation { get; set; }

    public string? ContactIg { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

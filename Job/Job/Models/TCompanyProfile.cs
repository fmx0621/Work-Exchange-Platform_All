using System;
using System.Collections.Generic;

namespace Job.Models;

public partial class TCompanyProfile
{
    public int ProfileId { get; set; }

    public int MemberId { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? ProfilePicture { get; set; }

    public string? Website { get; set; }

    public string? Fb { get; set; }

    public string? Ig { get; set; }

    public string Intro { get; set; } = null!;

    public string? Address { get; set; }

    public string? Type { get; set; }
}

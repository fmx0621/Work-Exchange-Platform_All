using System;
using System.Collections.Generic;

namespace Job.Models;

public partial class TWorkerProfile
{
    public int ProfileId { get; set; }

    public int MemberId { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string GenderCode { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string? ProfilePicture { get; set; }
}

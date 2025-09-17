using System;
using System.Collections.Generic;

namespace Job.Models;

public partial class TUserRecord
{
    public int UserRecordId { get; set; }

    public string? ApplicationRecord { get; set; }

    public DateOnly? ApplicationDate { get; set; }

    public string? AdmitRecord { get; set; }

    public string? WorkExperience { get; set; }

    public string? LoginIprecord { get; set; }

    public DateOnly? PasswordChangeDate { get; set; }

    public string? PasswordChangeHistory { get; set; }

    public int? MemberId { get; set; }
}

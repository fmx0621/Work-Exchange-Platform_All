using System;
using System.Collections.Generic;

namespace Job.Models;

public partial class TJobPosting
{
    public int PostingId { get; set; }

    public int? StatusId { get; set; }

    public int? UserId { get; set; }

    public string? PostTitle { get; set; }

    public DateTime? ApplicationDeadline { get; set; }

    public DateTime? PublishStartDate { get; set; }

    public DateTime? PublishEndDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

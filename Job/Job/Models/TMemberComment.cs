using System;
using System.Collections.Generic;

namespace Job.Models;

public partial class TMemberComment
{
    public int CommentId { get; set; }

    public string? MemberName { get; set; }

    public int? MemberId { get; set; }

    public string? Comment { get; set; }

    public int? Rating { get; set; }

    public DateOnly? DateTime { get; set; }

    public int? UserId { get; set; }

    public string? UserName { get; set; }

    public bool? Reviewed { get; set; }
}

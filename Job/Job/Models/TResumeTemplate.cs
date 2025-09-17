using System;
using System.Collections.Generic;

namespace Job.Models;

public partial class TResumeTemplate
{
    public int TemplateId { get; set; }

    public string TemplateName { get; set; } = null!;

    public string? TemplateTitle { get; set; }

    public string? TemplateDescription { get; set; }

    public string? TemplateHtml { get; set; }

    public string? TemplateCss { get; set; }

    public bool IsPremium { get; set; }

    public int? SortOrder { get; set; }

    public int UsageCount { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

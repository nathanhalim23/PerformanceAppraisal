using System;
using System.Collections.Generic;

namespace EmployeeAppraisalDataAccess.Models;

public partial class AppraisalForm
{
    public int Id { get; set; }

    public string? Nik { get; set; }

    public int? Periode { get; set; }

    public virtual ICollection<AreaResponsibilityIndicator> AreaResponsibilityIndicators { get; set; } = new List<AreaResponsibilityIndicator>();

    public virtual ICollection<BasicCompetency> BasicCompetencies { get; set; } = new List<BasicCompetency>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<ImprovementArea> ImprovementAreas { get; set; } = new List<ImprovementArea>();

    public virtual Employee? NikNavigation { get; set; }

    public virtual ICollection<PerformanceIndicator> PerformanceIndicators { get; set; } = new List<PerformanceIndicator>();

    public virtual ICollection<ScoreAdjustment> ScoreAdjustments { get; set; } = new List<ScoreAdjustment>();
}

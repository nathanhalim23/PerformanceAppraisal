using System;
using System.Collections.Generic;

namespace EmployeeAppraisalDataAccess.Models;

public partial class Employee
{
    public string Nik { get; set; } = null!;

    public string? Name { get; set; }

    public int? DivisionId { get; set; }

    public string? Position { get; set; }

    public string? SuperiorId { get; set; }

    public virtual ICollection<AppraisalForm> AppraisalForms { get; set; } = new List<AppraisalForm>();

    public virtual ICollection<AreaResponsibilityIndicator> AreaResponsibilityIndicators { get; set; } = new List<AreaResponsibilityIndicator>();

    public virtual ICollection<BasicCompetency> BasicCompetencies { get; set; } = new List<BasicCompetency>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Division? Division { get; set; }

    public virtual ICollection<ImprovementArea> ImprovementAreas { get; set; } = new List<ImprovementArea>();

    public virtual ICollection<Employee> InverseSuperior { get; set; } = new List<Employee>();

    public virtual ICollection<PerformanceIndicator> PerformanceIndicators { get; set; } = new List<PerformanceIndicator>();

    public virtual ICollection<ScoreAdjustment> ScoreAdjustments { get; set; } = new List<ScoreAdjustment>();

    public virtual Employee? Superior { get; set; }
}

using System;
using System.Collections.Generic;

namespace EmployeeAppraisalDataAccess.Models;

public partial class AreaResponsibilityIndicator
{
    public int Id { get; set; }

    public string? Nik { get; set; }

    public int? AuditScore { get; set; }

    public string? IsoSmk3Application { get; set; }

    public int? InternalAudit { get; set; }

    public int? ExternalAudit { get; set; }

    public int? Absent { get; set; }

    public int? SickLeave { get; set; }

    public int? Cpg { get; set; }

    public int? TwoHoursLeave { get; set; }

    public int? OneAbsence { get; set; }

    public int? LessThanFifteenMinLate { get; set; }

    public int? MoreThanFifteenMinLate { get; set; }

    public int? MoreThan4HoursTraining { get; set; }

    public int? FormId { get; set; }

    public virtual AppraisalForm? Form { get; set; }

    public virtual Employee? NikNavigation { get; set; }
}

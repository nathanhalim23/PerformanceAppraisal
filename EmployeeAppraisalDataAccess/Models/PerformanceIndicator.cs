using System;
using System.Collections.Generic;

namespace EmployeeAppraisalDataAccess.Models;

public partial class PerformanceIndicator
{
    public int Id { get; set; }

    public string? Nik { get; set; }

    public string? StrategicObjective { get; set; }

    public int? KpiId { get; set; }

    public string? UnitOfMeasurement { get; set; }

    public int? PolarizationId { get; set; }

    public int? Actual { get; set; }

    public int? FormId { get; set; }

    public virtual AppraisalForm? Form { get; set; }

    public virtual KpiMaster? Kpi { get; set; }

    public virtual Employee? NikNavigation { get; set; }

    public virtual PolarizationMaster? Polarization { get; set; }
}

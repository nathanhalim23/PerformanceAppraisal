using System;
using System.Collections.Generic;

namespace EmployeeAppraisalDataAccess.Models;

public partial class KpiMaster
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<PerformanceIndicator> PerformanceIndicators { get; set; } = new List<PerformanceIndicator>();
}

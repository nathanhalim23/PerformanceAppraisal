using System;
using System.Collections.Generic;

namespace EmployeeAppraisalDataAccess.Models;

public partial class BasicCompetency
{
    public int Id { get; set; }

    public string? Nik { get; set; }

    public int? FormId { get; set; }

    public int? CustomerFocus { get; set; }

    public int? Integrity { get; set; }

    public int? Teamwork { get; set; }

    public int? ContinuousImprovement { get; set; }

    public int? WorkExcellence { get; set; }

    public virtual AppraisalForm? Form { get; set; }

    public virtual Employee? NikNavigation { get; set; }
}

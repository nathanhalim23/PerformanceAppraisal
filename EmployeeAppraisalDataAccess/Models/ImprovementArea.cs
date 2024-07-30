using System;
using System.Collections.Generic;

namespace EmployeeAppraisalDataAccess.Models;

public partial class ImprovementArea
{
    public int Id { get; set; }

    public string? Nik { get; set; }

    public string? ImprovementAreaNeeded { get; set; }

    public string? ImorovementMethod { get; set; }

    public int? FormId { get; set; }

    public virtual AppraisalForm? Form { get; set; }

    public virtual Employee? NikNavigation { get; set; }
}

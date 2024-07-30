using System;
using System.Collections.Generic;

namespace EmployeeAppraisalDataAccess.Models;

public partial class ScoreAdjustment
{
    public int Id { get; set; }

    public string? Nik { get; set; }

    public bool? IsWarningLetter { get; set; }

    public bool? IsFireIncident { get; set; }

    public bool? IsLostTimeInjury { get; set; }

    public bool? IsProject { get; set; }

    public bool? IsSga { get; set; }

    public bool? IsAuditorOrTrainer { get; set; }

    public int? FormId { get; set; }

    public virtual AppraisalForm? Form { get; set; }

    public virtual Employee? NikNavigation { get; set; }
}

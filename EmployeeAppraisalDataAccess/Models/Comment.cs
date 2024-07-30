using System;
using System.Collections.Generic;

namespace EmployeeAppraisalDataAccess.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string? Nik { get; set; }

    public string? EmployeeComment { get; set; }

    public string? AppraiserComment { get; set; }

    public int? FormId { get; set; }

    public virtual AppraisalForm? Form { get; set; }

    public virtual Employee? NikNavigation { get; set; }
}

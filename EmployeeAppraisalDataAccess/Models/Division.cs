using System;
using System.Collections.Generic;

namespace EmployeeAppraisalDataAccess.Models;

public partial class Division
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}

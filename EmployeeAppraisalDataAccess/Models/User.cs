using System;
using System.Collections.Generic;

namespace EmployeeAppraisalDataAccess.Models;

public partial class User
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string? Role { get; set; }
}

using System;
using System.Collections.Generic;

namespace CustomValidation.Models;

public partial class Employee {
    public int EmployeeId { get; set; }
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string? Title { get; set; }
    public DateTime? HireDate { get; set; }

}

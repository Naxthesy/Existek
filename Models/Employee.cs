using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Existek.Models
{
    public partial class Employee
    {
        public int EmployeetId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string PhotoFileName { get; set; }
    }
}

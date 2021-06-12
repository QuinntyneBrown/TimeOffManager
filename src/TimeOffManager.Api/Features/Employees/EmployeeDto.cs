using System;
using TimeOffManager.Api.Models;

namespace TimeOffManager.Api.Features
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public Skill Skill { get; set; }
        public bool SixMonthReviewRequired { get; set; }
    }
}

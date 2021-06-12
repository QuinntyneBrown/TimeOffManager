using System;
using System.Collections.Generic;
using TimeOffManager.Api.Models;

namespace TimeOffManager.Api.Features
{
    public class DevelopmentTeamDto
    {
        public Guid DevelopmentTeamId { get; set; }
        public AgileMethodology AgileMethodology { get; set; }
        public bool Hiring { get; set; }
        public List<EmployeeDto> Employees { get; set; }
    }
}

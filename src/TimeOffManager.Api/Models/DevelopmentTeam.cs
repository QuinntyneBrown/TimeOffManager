using System;
using System.Collections.Generic;

namespace TimeOffManager.Api.Models
{
    public class DevelopmentTeam
    {
        public Guid DevelopmentTeamId { get; private set; }
        public AgileMethodology AgileMethodology { get; private set; }
        public bool Hiring { get; set; }
        public List<Employee> Employees { get; private set; } = new();

        public DevelopmentTeam(
            AgileMethodology agileMethodology = AgileMethodology.Scrum,
            bool hiring = false
            )
        {
            AgileMethodology = agileMethodology;
            Hiring = hiring;
        }

        public void SetEmployees(List<Employee> employees)
        {
            Employees = employees;
        }
        public DevelopmentTeam()
        {

        }
    }
}

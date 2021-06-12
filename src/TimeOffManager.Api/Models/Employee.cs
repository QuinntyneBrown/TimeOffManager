using System;

namespace TimeOffManager.Api.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; private set; }
        public Guid DevelopmentTeamId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime HireDate { get; private set; }
        public bool SixMonthReviewRequired { get; private set; }
        public Skill Skill { get; private set; }
        public DevelopmentTeam DevelopmentTeam { get; private set; }
        public Employee(string name, string email, DateTime hireDate, bool sixMonthReviewRequired, Skill skill = Skill.Backend)
        {
            Name = name;
            Email = email;
            HireDate = hireDate;
            SixMonthReviewRequired = sixMonthReviewRequired;
            Skill = skill;
        }

        private Employee()
        {

        }

        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}

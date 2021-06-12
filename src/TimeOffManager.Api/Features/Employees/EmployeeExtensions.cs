using System;
using TimeOffManager.Api.Models;

namespace TimeOffManager.Api.Features
{
    public static class EmployeeExtensions
    {
        public static EmployeeDto ToDto(this Employee employee)
        {
            return new ()
            {
                EmployeeId = employee.EmployeeId
            };
        }
        
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TimeOffManager.Api.Interfaces;
using TimeOffManager.Api.Models;

namespace TimeOffManager.Api.Features
{
    public class CreateEmployees
    {
        public class Request : IRequest<Response> {
            public List<EmployeeDto> Employees { get; set; }
        }

        public class Response
        {
            public List<EmployeeDto> Employees { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly ITimeOffManagerDbContext _context;

            public Handler(ITimeOffManagerDbContext context){
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
                var employees = new List<Employee>();

			    foreach(var employeeDto in request.Employees)
                {
                    var employee = new Employee(
                    employeeDto.Name,
                    employeeDto.Email,
                    employeeDto.HireDate,
                    employeeDto.SixMonthReviewRequired,
                    employeeDto.Skill
                    );

                    employees.Add(employee);
                }

                _context.Employees.AddRange(employees);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Employees = employees.Select(x => x.ToDto()).ToList()
                };
            }
        }
    }
}

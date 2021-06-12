using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeOffManager.Api.Core;
using TimeOffManager.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace TimeOffManager.Api.Features
{
    public class UpdateEmployeeName
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.EmployeeId).NotNull();
                RuleFor(request => request.Name).NotNull();
            }        
        }

        public class Request: IRequest<Response>
        {
            public Guid EmployeeId { get; set; }
            public string Name { get; set; }
        }

        public class Response: ResponseBase
        {
            public EmployeeDto Employee { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ITimeOffManagerDbContext _context;
        
            public Handler(ITimeOffManagerDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var employee = await _context.Employees.SingleAsync(x => x.EmployeeId == request.EmployeeId);

                employee.UpdateName(request.Name);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new ()
                {
                    Employee = employee.ToDto()
                };
            }
            
        }
    }
}

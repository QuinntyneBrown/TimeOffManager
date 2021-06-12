using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using TimeOffManager.Api.Models;
using TimeOffManager.Api.Core;
using TimeOffManager.Api.Interfaces;

namespace TimeOffManager.Api.Features
{
    public class RemoveEmployee
    {
        public class Request: IRequest<Response>
        {
            public Guid EmployeeId { get; set; }
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
                
                _context.Employees.Remove(employee);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Employee = employee.ToDto()
                };
            }
            
        }
    }
}

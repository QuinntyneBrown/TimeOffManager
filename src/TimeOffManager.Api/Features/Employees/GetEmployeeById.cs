using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeOffManager.Api.Core;
using TimeOffManager.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TimeOffManager.Api.Features
{
    public class GetEmployeeById
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
                return new () {
                    Employee = (await _context.Employees.SingleOrDefaultAsync(x => x.EmployeeId == request.EmployeeId)).ToDto()
                };
            }
            
        }
    }
}

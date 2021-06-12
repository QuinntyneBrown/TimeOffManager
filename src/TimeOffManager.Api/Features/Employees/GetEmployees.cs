using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using TimeOffManager.Api.Core;
using TimeOffManager.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TimeOffManager.Api.Features
{
    public class GetEmployees
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<EmployeeDto> Employees { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ITimeOffManagerDbContext _context;
        
            public Handler(ITimeOffManagerDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Employees = await _context.Employees.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}

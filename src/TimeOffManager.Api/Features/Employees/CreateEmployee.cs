using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeOffManager.Api.Models;
using TimeOffManager.Api.Core;
using TimeOffManager.Api.Interfaces;

namespace TimeOffManager.Api.Features
{
    public class CreateEmployee
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Employee).NotNull();
                RuleFor(request => request.Employee).SetValidator(new EmployeeValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public EmployeeDto Employee { get; set; }
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
                var employee = new Employee();
                
                _context.Employees.Add(employee);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Employee = employee.ToDto()
                };
            }
            
        }
    }
}

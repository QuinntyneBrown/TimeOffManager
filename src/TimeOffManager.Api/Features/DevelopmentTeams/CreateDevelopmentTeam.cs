using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeOffManager.Api.Models;
using TimeOffManager.Api.Core;
using TimeOffManager.Api.Interfaces;

namespace TimeOffManager.Api.Features
{
    public class CreateDevelopmentTeam
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.DevelopmentTeam).NotNull();
                RuleFor(request => request.DevelopmentTeam).SetValidator(new DevelopmentTeamValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public DevelopmentTeamDto DevelopmentTeam { get; set; }
        }

        public class Response: ResponseBase
        {
            public DevelopmentTeamDto DevelopmentTeam { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ITimeOffManagerDbContext _context;
        
            public Handler(ITimeOffManagerDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var developmentTeam = new DevelopmentTeam();
                
                _context.DevelopmentTeams.Add(developmentTeam);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    DevelopmentTeam = developmentTeam.ToDto()
                };
            }
            
        }
    }
}

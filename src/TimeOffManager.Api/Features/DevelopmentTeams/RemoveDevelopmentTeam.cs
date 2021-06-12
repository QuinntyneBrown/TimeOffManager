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
    public class RemoveDevelopmentTeam
    {
        public class Request: IRequest<Response>
        {
            public Guid DevelopmentTeamId { get; set; }
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
                var developmentTeam = await _context.DevelopmentTeams.SingleAsync(x => x.DevelopmentTeamId == request.DevelopmentTeamId);
                
                _context.DevelopmentTeams.Remove(developmentTeam);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    DevelopmentTeam = developmentTeam.ToDto()
                };
            }
            
        }
    }
}

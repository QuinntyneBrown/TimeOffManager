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
    public class GetDevelopmentTeams
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<DevelopmentTeamDto> DevelopmentTeams { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ITimeOffManagerDbContext _context;
        
            public Handler(ITimeOffManagerDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    DevelopmentTeams = await _context.DevelopmentTeams.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}

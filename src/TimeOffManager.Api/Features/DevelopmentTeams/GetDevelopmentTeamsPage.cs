using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TimeOffManager.Api.Extensions;
using TimeOffManager.Api.Core;
using TimeOffManager.Api.Interfaces;
using TimeOffManager.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace TimeOffManager.Api.Features
{
    public class GetDevelopmentTeamsPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<DevelopmentTeamDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ITimeOffManagerDbContext _context;
        
            public Handler(ITimeOffManagerDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from developmentTeam in _context.DevelopmentTeams
                    select developmentTeam;
                
                var length = await _context.DevelopmentTeams.CountAsync();
                
                var developmentTeams = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = developmentTeams
                };
            }
            
        }
    }
}

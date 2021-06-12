using System.Net;
using System.Threading.Tasks;
using TimeOffManager.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TimeOffManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevelopmentTeamController
    {
        private readonly IMediator _mediator;

        public DevelopmentTeamController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{developmentTeamId}", Name = "GetDevelopmentTeamByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDevelopmentTeamById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDevelopmentTeamById.Response>> GetById([FromRoute]GetDevelopmentTeamById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.DevelopmentTeam == null)
            {
                return new NotFoundObjectResult(request.DevelopmentTeamId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetDevelopmentTeamsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDevelopmentTeams.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDevelopmentTeams.Response>> Get()
            => await _mediator.Send(new GetDevelopmentTeams.Request());
        
        [HttpPost(Name = "CreateDevelopmentTeamRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateDevelopmentTeam.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateDevelopmentTeam.Response>> Create([FromBody]CreateDevelopmentTeam.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetDevelopmentTeamsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDevelopmentTeamsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDevelopmentTeamsPage.Response>> Page([FromRoute]GetDevelopmentTeamsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateDevelopmentTeamRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateDevelopmentTeam.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateDevelopmentTeam.Response>> Update([FromBody]UpdateDevelopmentTeam.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{developmentTeamId}", Name = "RemoveDevelopmentTeamRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveDevelopmentTeam.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveDevelopmentTeam.Response>> Remove([FromRoute]RemoveDevelopmentTeam.Request request)
            => await _mediator.Send(request);
        
    }
}

using System.Net;
using System.Threading.Tasks;
using TimeOffManager.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TimeOffManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{employeeId}", Name = "GetEmployeeByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetEmployeeById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetEmployeeById.Response>> GetById([FromRoute]GetEmployeeById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Employee == null)
            {
                return new NotFoundObjectResult(request.EmployeeId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetEmployeesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetEmployees.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetEmployees.Response>> Get()
            => await _mediator.Send(new GetEmployees.Request());
        
        [HttpPost(Name = "CreateEmployeeRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateEmployee.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateEmployee.Response>> Create([FromBody]CreateEmployee.Request request)
            => await _mediator.Send(request);

        [HttpPost("range", Name = "CreateEmployeesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateEmployees.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateEmployees.Response>> CreateRange([FromBody] CreateEmployees.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetEmployeesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetEmployeesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetEmployeesPage.Response>> Page([FromRoute]GetEmployeesPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateEmployeeRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateEmployeeName.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateEmployeeName.Response>> Update([FromBody]UpdateEmployeeName.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{employeeId}", Name = "RemoveEmployeeRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveEmployee.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveEmployee.Response>> Remove([FromRoute]RemoveEmployee.Request request)
            => await _mediator.Send(request);
        
    }
}

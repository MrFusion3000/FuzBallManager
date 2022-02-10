using Application.Commands;
using Application.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets Manager data.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetManagerQuery()));
        }

        /// <summary>
        /// Creates a New Manager.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ManagerResponse>> CreateManager([FromBody] CreateManagerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}

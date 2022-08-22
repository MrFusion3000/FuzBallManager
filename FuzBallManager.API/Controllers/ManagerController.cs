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
        /// Gets all Managers data.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllManagersQuery()));
        }

        /// <summary>
        /// Gets Manager data.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("GetManager/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetManager(string name )
        {
            return Ok(await _mediator.Send(new GetManagerQuery { Name = name }));
        }

        /// <summary>
        /// Creates a New Manager.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ManagerResponse>> CreateManager(CreateManagerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Updates a Manager.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("UpdateManager/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateManager(Guid id, [FromBody] UpdateManagerCommand command)
        {
            command.ManagerID = id;
            return Ok(await _mediator.Send(command));
        }
    }
}

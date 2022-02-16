using Application.Commands;
using Application.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixtureController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FixtureController(IMediator mediator)
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
            return Ok(await _mediator.Send(new GetAllFixturesQuery()));
        }

        /// <summary>
        /// Gets Manager data.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetFixture/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFixture(Guid id)
        {
            return Ok(await _mediator.Send(new GetFixtureQuery { FixtureID = id }));
        }

        /// <summary>
        /// Creates a New Manager.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ManagerResponse>> CreateFixture([FromBody] CreateFixtureCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}

using Application.Commands;
using Application.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PlayerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets all Players.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllPlayersQuery()));
        }

        /// <summary>
        /// Gets all Players.
        /// </summary>
        /// <param name="teamname"></param>
        /// <returns></returns>
        [HttpGet("GetPlayersByTeamName/{teamname}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPlayersByTeamName(string teamname)
        {
            return Ok(await _mediator.Send(new GetPlayersByTeamNameQuery { TeamName = teamname}));
        }

        /// <summary>
        /// Creates a New Player.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PlayerResponse>> CreatePlayer([FromBody] CreatePlayerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Updates a Player.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("UpdatePlayer/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdatePlayer(Guid id, [FromBody] UpdatePlayerCommand command)
        {
            command.PlayerID = id;
            return Ok(await _mediator.Send(command));
        }
    }
}

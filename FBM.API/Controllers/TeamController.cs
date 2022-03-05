using Application.Commands;
using Application.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get Team data by TeamName
        /// </summary>
        /// <param name="teamname"></param>
        /// <returns></returns>
        [HttpGet("GetByTeamName/{teamname}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByTeamName(string teamname)
        {
            return Ok(await _mediator.Send(new GetTeamQuery { TeamName = teamname }));
        }

        /// <summary>
        /// Get Team data by TeamId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetByTeamId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByTeamId(Guid id)
        {
            return Ok(await _mediator.Send(new GetTeamByIdQuery { TeamID = id }));
        }

        /// <summary>
        /// Get All Teams data.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllTeams()
        {
            return Ok(await _mediator.Send(new GetAllTeamsQuery()));
        }

        /// <summary>
        /// Creates a New Team.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TeamResponse>> CreateTeam([FromBody] CreateTeamCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}

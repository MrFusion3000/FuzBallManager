using Application.Commands;
using Application.Mappers;
using Application.Responses;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.CommandHandlers
{
    public class CreateTeamHandler : IRequestHandler<CreateTeamCommand, TeamResponse>
    {
        private readonly ITeamRepository _teamRepo;
        public CreateTeamHandler(ITeamRepository teamRepository)
        {
            _teamRepo = teamRepository;
        }
        public async Task<TeamResponse> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var teamEntity = TeamMapper.Mapper.Map<Team>(request);

            ArgumentNullException.ThrowIfNull(teamEntity);

            var newTeam = await _teamRepo.AddAsync(teamEntity);
            var teamResponse = TeamMapper.Mapper.Map<TeamResponse>(newTeam);

            return teamResponse;
        }
    }
}

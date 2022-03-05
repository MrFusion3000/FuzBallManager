using Domain.Entities;
using MediatR;

namespace Application.Queries;

public class GetTeamQuery : IRequest<Team>
{
    public string? TeamName { get; set; }
}

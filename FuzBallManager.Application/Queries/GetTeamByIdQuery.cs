using Domain.Entities;
using MediatR;

namespace Application.Queries;

public class GetTeamByIdQuery : IRequest<Team>
{
    public Guid? TeamID { get; set; }
}

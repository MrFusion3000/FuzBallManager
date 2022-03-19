using MediatR;

namespace Application.Commands;

public class DeleteFixtureCommand : IRequest<Guid>
{
    public Guid FixtureID { get; set; }
}

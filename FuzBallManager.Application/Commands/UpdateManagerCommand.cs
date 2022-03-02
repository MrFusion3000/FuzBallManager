using Application.Responses;
using MediatR;

namespace Application.Commands;

public class UpdateManagerCommand : IRequest<Guid>
{
    public Guid ManagerID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int Score { get; set; }
    public int Bank { get; set; }
    public Guid ManagingTeamID { get; set; }
    public string? ManagingTeamName { get; set; }
}

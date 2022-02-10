using Application.Responses;
using MediatR;

namespace Application.Commands
{
    public class CreateManagerCommand : IRequest<ManagerResponse>
    {
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public int Score { get; set; }
        public int Bank { get; set; }
        public Guid ManagingTeamID { get; set; }
        public string? ManagingTeamName { get; set; }
    }
}

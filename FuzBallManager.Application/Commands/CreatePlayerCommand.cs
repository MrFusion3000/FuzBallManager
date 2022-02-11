using Application.Responses;
using MediatR;

namespace Application.Commands
{
    public class CreatePlayerCommand : IRequest<PlayerResponse>
    {
        public string? PlayerFirstName { get; set; }
        public string? PlayerLastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PlayerPosition { get; set; }
        public int? PlayerStats { get; set; }
        public string? TeamName { get; set; }
    }
}

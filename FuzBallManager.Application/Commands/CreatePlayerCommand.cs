using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreatePlayerCommand : IRequest<PlayerResponse>
    {
        public string? PlayerFirstName { get; set; }
        public string? PlayerLastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

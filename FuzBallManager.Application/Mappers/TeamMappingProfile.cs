using Application.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class TeamMappingProfile : Profile
    {
        public TeamMappingProfile()
        {
            CreateMap<Team, TeamResponse>().ReverseMap();
            CreateMap<Team, CreateTeamCommand>().ReverseMap();
        }
    }
}
